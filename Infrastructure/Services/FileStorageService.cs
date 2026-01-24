using Amazon.S3;
using Amazon.S3.Model;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;

namespace Infrastructure.Services;

public class FileStorageService(IConfiguration configuration, IAmazonS3 s3) : IFileStorageService
{
    private readonly IAmazonS3 _s3 = s3;

    public async Task<string> UploadFile(string folder, IFormFile file, string? fileName = null)
    {
        if (file.Length <= 0)
            throw new CantUploadEmptyFileBadRequestException();

        var bucketName = configuration.GetSection("ObjectStorage:BucketName")
            .Get<string>() ?? throw new InvalidOperationException("Bucket name not specified");
        var maxFileSize = int.Parse(configuration.GetSection("ObjectStorage:MaxFileSize")
            .Get<string>() ?? "10485760");
        var extensions = configuration.GetSection("ObjectStorage:AllowedExtensions")
            .Get<string[]>() ?? [".jpg", ".jpeg", ".png"];


        if (file.Length > maxFileSize)
            throw new InvalidOperationException("File size exceeds the maximum limit.");

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!extensions.Contains(extension))
            throw new InvalidOperationException($"File extension ({extension}) is not allowed.");

        string key;
        folder = folder.Trim();
        if (!string.IsNullOrWhiteSpace(folder))
        {
            if (folder.EndsWith("\\") || folder.EndsWith("/"))
                folder = folder[..^1];

            key = $"{folder}/{fileName + DateTime.Now.ToString("yyyyMMddHHmm")}{extension}";
        }
        else
            key = $"{fileName + DateTime.Now.ToString("yyyyMMddHHmm")}{extension}";

        await using var stream = file.OpenReadStream();
        var uploadRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = key,
            InputStream = stream,
            ContentType = file.ContentType,
            AutoCloseStream = true
        };

        await _s3.PutObjectAsync(uploadRequest);
        return key;
    }

    public async Task DeleteFiles(string s3Key)
    {
        var bucketName = configuration.GetValue<string>("ObjectStorage:BucketName")
                         ?? throw new InvalidOperationException("Bucket name not specified");

        var deleteRequest = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = s3Key
        };

        await _s3.DeleteObjectAsync(deleteRequest);
    }

    public async Task<string> GetFileUrl(string s3Key, bool viewOnly = false)
    {
        var bucketName = configuration.GetSection("ObjectStorage:BucketName")
            .Get<string>() ?? throw new InvalidOperationException("Bucket name not specified");

        var request = new GetPreSignedUrlRequest
        {
            BucketName = bucketName,
            Key = s3Key,
            Expires = DateTime.UtcNow.AddMinutes(10),
            Verb = HttpVerb.GET,
            ResponseHeaderOverrides = viewOnly
                ? null
                : new ResponseHeaderOverrides { ContentDisposition = "attachment" }
        };

        return await _s3.GetPreSignedURLAsync(request);
    }


    public async Task<List<string>> GetFileUrlsInPathAsync(string prefix, bool viewOnly = false)
    {
        var keys = await ListFilesInPathAsync(prefix);
        var urls = new List<string>();

        foreach (var key in keys)
        {
            var url = await GetFileUrl(key, viewOnly);
            urls.Add(url);
        }

        return urls;
    }

    private async Task<List<string>> ListFilesInPathAsync(string prefix)
    {
        var bucketName = configuration.GetSection("ObjectStorage:BucketName")
            .Get<string>() ?? throw new InvalidOperationException("Bucket name not specified");

        var s3Keys = new List<string>();
        string? continuationToken = null;

        do
        {
            var request = new ListObjectsV2Request
            {
                BucketName = bucketName,
                Prefix = prefix,
                ContinuationToken = continuationToken
            };

            var response = await _s3.ListObjectsV2Async(request);

            s3Keys.AddRange(response.S3Objects.Select(obj => obj.Key));
            continuationToken = response.IsTruncated ? response.NextContinuationToken : null;
        } while (continuationToken != null);

        return s3Keys;
    }
}
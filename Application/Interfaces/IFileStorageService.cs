using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IFileStorageService
{
    Task<string> UploadFile(string folder, IFormFile file, string? fileName = null);
    Task DeleteFiles(string s3Key);
    Task<string> GetFileUrl(string s3Key, bool viewOnly = false);
    Task<List<string>> GetFileUrlsInPathAsync(string prefix, bool viewOnly = false);
}
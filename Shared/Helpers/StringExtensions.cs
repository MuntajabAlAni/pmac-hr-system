using System.Security.Cryptography;

namespace Shared.Helpers;

public static class StringExtensions
{
    public static string HashPassword(this string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));

        using var bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8, HashAlgorithmName.SHA256);
        var salt = bytes.Salt;
        var buffer2 = bytes.GetBytes(0x20);

        var dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }

    public static bool VerifyHashedPassword(this string password, string? hashedPassword)
    {
        if (string.IsNullOrEmpty(hashedPassword))
            return false;
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));

        var src = Convert.FromBase64String(hashedPassword);
        if ((src.Length != 0x31) || (src[0] != 0))
            return false;

        var dst = new byte[0x10];
        Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        var buffer3 = new byte[0x20];
        Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
        using var bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8, HashAlgorithmName.SHA256);
        var buffer4 = bytes.GetBytes(0x20);

        return ByteArraysEqual(buffer3, buffer4);
    }

    private static bool ByteArraysEqual(IReadOnlyCollection<byte>? b1, IReadOnlyList<byte>? b2)
    {
        if (Equals(b1, b2)) return true;
        if (b1 == null || b2 == null) return false;
        if (b1.Count != b2.Count) return false;
        return !b1.Where((t, i) => t != b2[i]).Any();
    }
}
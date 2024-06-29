using System.Security.Cryptography;
using System.Text;

namespace TalentTrek.Api.Utils;
internal class Crypto
{
    private static readonly int keySize = 64;
    private static readonly int iterations = 350000;
    private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

    // PBKDF2
    // BCrypt/SCrypt
    // Argon2
    
    public static byte[] GenerateSalt()
    {
        return RandomNumberGenerator.GetBytes(keySize);
    }

    public static string HashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(keySize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password), 
            salt, 
            iterations, 
            hashAlgorithm, 
            keySize
        );

        return Convert.ToHexString(hash);
    }

    public static bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password), 
            salt, 
            iterations, 
            hashAlgorithm, 
            keySize
        );

        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}
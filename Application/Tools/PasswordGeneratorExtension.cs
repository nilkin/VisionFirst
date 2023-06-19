using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
    public static class PasswordGeneratorExtension
    {
        public static byte[] GenerateSalt(int saltSize)
        {
            byte[] salt = new byte[saltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
public static string HashPassword(string password, byte[] salt)
{
    int iterations = 10000;
    int hashLength = 32;
    byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
    using (var pbkdf2 = new Rfc2898DeriveBytes(passwordBytes, salt, iterations, HashAlgorithmName.SHA256))
    {
        byte[] hash = pbkdf2.GetBytes(hashLength);
        byte[] hashBytes = new byte[hashLength + salt.Length];
        Array.Copy(salt, 0, hashBytes, 0, salt.Length);
        Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);
        return Convert.ToBase64String(hashBytes);
    }
}


        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            int saltLength = hashBytes.Length - 32;
            byte[] salt = new byte[saltLength];
            Array.Copy(hashBytes, 0, salt, 0, saltLength);
            string newHash = HashPassword(password, salt);

            // Compare the two hashes
            return hashedPassword.Equals(newHash);
        }
    }
}

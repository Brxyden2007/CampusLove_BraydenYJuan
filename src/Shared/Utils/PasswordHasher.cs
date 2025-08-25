using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CampusLove_BraydenYJuan.src.Shared.Utils;
public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        string computedHash = Convert.ToBase64String(bytes);

        return storedHash == computedHash;
    }    
}

using System.Security.Cryptography;
using System.Text;

namespace Expense.Helpers;

public static class PasswordManager
{
    public static string Hash(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes((password)));
        var hashedPassword = new StringBuilder();
        foreach(var b in bytes)
        {
            hashedPassword.Append(b.ToString("x2"));
        }
        return hashedPassword.ToString();
    }
}
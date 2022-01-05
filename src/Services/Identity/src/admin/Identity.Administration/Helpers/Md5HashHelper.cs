using System.Security.Cryptography;
using System.Text;

namespace Identity.Administration.Helpers;

public static class Md5HashHelper
{
    public static string GetHash(string input)
    {
        using (var md5 = MD5.Create())
        {
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            foreach (var dataByte in bytes)
            {
                sBuilder.Append(dataByte.ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
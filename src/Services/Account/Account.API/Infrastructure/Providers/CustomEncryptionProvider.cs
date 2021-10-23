using System;
using System.Security.Cryptography;
using System.Text;

namespace Account.API.Infrastructure.Providers
{
    public class CustomEncryptionProvider : IEncryptionProvider
    {
        private const string Key = "cxz92k13md8f981hu6y7alkc";
        public string Encrypt(string value)
        {
            var inputs = Encoding.UTF8.GetBytes(value);
            var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(Key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var transform = tripleDes.CreateEncryptor();
            var results = transform.TransformFinalBlock(inputs, 0, inputs.Length);
            tripleDes.Clear();
            return Convert.ToBase64String(results, 0, results.Length);
        }

        public string Decrypt(string value)
        {
            var inputs = Convert.FromBase64String(value);
            var tripleDes = new TripleDESCryptoServiceProvider
            {
                Key = Encoding.UTF8.GetBytes(Key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var transform = tripleDes.CreateDecryptor();
            var results = transform.TransformFinalBlock(inputs, 0, inputs.Length);
            tripleDes.Clear();
            return Encoding.UTF8.GetString(results);
        }
    }
}

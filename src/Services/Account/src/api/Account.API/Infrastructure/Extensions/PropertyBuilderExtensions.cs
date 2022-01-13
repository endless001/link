using Account.API.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.API.Infrastructure.Extensions
{
    public static class PropertyBuilderExtensions
    {

        public static PropertyBuilder<string> Encrypted(this PropertyBuilder<string> property, IEncryptionProvider encryptionProvider)
        {

            return property.HasConversion(
               val => encryptionProvider.Encrypt(val),
               val => encryptionProvider.Decrypt(val));
        }

    }
}

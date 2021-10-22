using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.API.Infrastructure.Extensions
{
    public static class PropertyBuilderExtensions
    {

        public static PropertyBuilder<string> IsEncrypted(this PropertyBuilder<string> property, IEncryptionProvider encryptionProvider)
        {

            return property.HasConversion(
               val => encryptionProvider.Encrypt(val),
               val => val.Decrypt());
        }

    }
}

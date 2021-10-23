namespace Account.API.Infrastructure.Providers
{
  public interface IEncryptionProvider
  {
    string Encrypt(string dataToEncrypt);
    string Decrypt(string dataToDecrypt);
  }
}

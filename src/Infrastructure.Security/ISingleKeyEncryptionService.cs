namespace Infrastructure.Security
{
    public interface ISingleKeyEncryptionService
    {
        string EncryptString(string data);
        string DecryptString(string data);
    }
}
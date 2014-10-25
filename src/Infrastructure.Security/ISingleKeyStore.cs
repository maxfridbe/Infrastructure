namespace Infrastructure.Security
{
    public interface ISingleKeyStore
    {
        string GetKey();
        void SetKey(string key);
    }
}
using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Security
{
    public class SingleKeyEncryptionService : ISingleKeyEncryptionService
    {
        private readonly IPasswordHashProvider _passwordHashProvider;
         private MD5CryptoServiceProvider _hashmd5;
        private byte[] _hashEnc;
        public SingleKeyEncryptionService(ISingleKeyStore keystore)
        {
            //_passwordHashProvider = passwordHashProvider;
            var hash = keystore.GetKey();

            if (string.IsNullOrWhiteSpace(hash))
            {
                var tDes = new TripleDESCryptoServiceProvider();
                tDes.GenerateKey();
                keystore.SetKey(Convert.ToBase64String(tDes.Key));
                hash=keystore.GetKey();
            }
            
            _hashmd5 = new MD5CryptoServiceProvider();
            _hashEnc = Encoding.UTF8.GetBytes(hash);
            //_hash = key

        }
        public string EncryptString(string data)
        {
            byte[] toEncrypt = Encoding.UTF8.GetBytes(data);
            var tDes = new TripleDESCryptoServiceProvider();

            tDes.GenerateIV();

            var key = _hashmd5.ComputeHash(_hashEnc);
            var bytes = TripleDes.Encrypt(toEncrypt, key, tDes.IV);

            var str = Convert.ToBase64String(bytes, 0, bytes.Length);
            var iv = Convert.ToBase64String(tDes.IV, 0, tDes.IV.Length);
            var res = string.Format("{0}|{1}", str, iv);
            return res;
        }

        public string DecryptString(string data)
        {
            var d = data.Split(new[] { '|' });
            var encrypteddata = Convert.FromBase64String(d[0]);
            var iv = Convert.FromBase64String(d[1]);

            var key = _hashmd5.ComputeHash(_hashEnc);
            var dec = TripleDes.Decrypt(encrypteddata, key, iv);

            //Convert the buffer into a string and return it. 
            return Encoding.UTF8.GetString(dec).TrimEnd('\0');
        }
    }
}
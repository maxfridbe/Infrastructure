using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public static class TripleDes
    {
        public static byte[] Encrypt(byte[] toEncrypt, byte[] Key, byte[] IV)
        {
            try
            {
                byte[] result;
                // Create a MemoryStream.
                using (var memoryStream = new MemoryStream())
                // Create a CryptoStream using the MemoryStream  
                // and the passed key and initialization vector (IV).
                using (var cryptoStream = new CryptoStream(memoryStream, new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    // Write the byte array to the crypto stream and flush it.
                    cryptoStream.Write(toEncrypt, 0, toEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    // Get an array of bytes from the  
                    // MemoryStream that holds the  
                    // encrypted data. 
                    result = memoryStream.ToArray();
                    // Close the streams.
                    cryptoStream.Close();
                    memoryStream.Close();
                }

                // Return the encrypted buffer. 
                return result;

            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

        }

        public static byte[] Decrypt(byte[] Data, byte[] Key, byte[] IV)
        {
            try
            {
                // Create a new MemoryStream using the passed  
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(Data);

                // Create a CryptoStream using the MemoryStream  
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
                    CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data. 
                byte[] fromEncrypt = new byte[Data.Length];

                // Read the decrypted data out of the crypto stream 
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }

            
        }
    }
}

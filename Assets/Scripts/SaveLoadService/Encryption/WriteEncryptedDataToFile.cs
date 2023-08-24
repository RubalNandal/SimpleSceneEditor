using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace RubalNandal.SaveLoadService.Encryption
{
    /// <summary>
    /// A class that provides methods to write encrypted data to a file.
    /// </summary>
    public class WriteEncryptedDataToFile
    {
        private const string KEY = "ggdPhkeOoiv6YMiPWa34kIuOdDUL7NwQFg6l1DVdwN8=";
        private const string IV = "JZuM0HQsWSBVpRHTeRZMYQ==";

        /// <summary>
        /// Writes encrypted data of type T to the provided file stream.
        /// </summary>
        /// <typeparam name="T">The type of data to be written.</typeparam>
        /// <param name="Data">The data to be encrypted and written.</param>
        /// <param name="Stream">The file stream to which the encrypted data is written.</param>
        public void WriteEncryptedData<T>(T Data, FileStream Stream)
        {
            using Aes aesProvider = Aes.Create();
            aesProvider.Key = Convert.FromBase64String(KEY);
            aesProvider.IV = Convert.FromBase64String(IV);

            // Create an encryption transform and a CryptoStream to write the encrypted data.
            using ICryptoTransform cryptoTransform = aesProvider.CreateEncryptor();
            using CryptoStream cryptoStream = new CryptoStream(
                Stream,
                cryptoTransform,
                CryptoStreamMode.Write
            );

            // Serialize the data to JSON and write it to the CryptoStream.
            cryptoStream.Write(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(Data)));
        }
    }
}
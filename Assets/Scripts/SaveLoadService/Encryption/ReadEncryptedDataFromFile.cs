using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

namespace RubalNandal.SaveLoadService.Encryption
{
    /// <summary>
    /// A class that provides methods to read encrypted data from a file.
    /// </summary>
    public class ReadEncryptedDataFromFile
    {
        private const string KEY = "ggdPhkeOoiv6YMiPWa34kIuOdDUL7NwQFg6l1DVdwN8=";
        private const string IV = "JZuM0HQsWSBVpRHTeRZMYQ==";

        /// <summary>
        /// Reads and decrypts encrypted data of type T from the specified file.
        /// </summary>
        /// <typeparam name="T">The type of data to be read and deserialized.</typeparam>
        /// <param name="Path">The path to the encrypted file.</param>
        /// <returns>The decrypted and deserialized data.</returns>
        public T ReadEncryptedData<T>(string Path)
        {
            byte[] fileBytes = File.ReadAllBytes(Path);
            using Aes aesProvider = Aes.Create();

            aesProvider.Key = Convert.FromBase64String(KEY);
            aesProvider.IV = Convert.FromBase64String(IV);

            // Create a decryption transform and read the decrypted data.
            using ICryptoTransform cryptoTransform = aesProvider.CreateDecryptor(
                aesProvider.Key,
                aesProvider.IV
            );
            using MemoryStream decryptionStream = new MemoryStream(fileBytes);
            using CryptoStream cryptoStream = new CryptoStream(
                decryptionStream,
                cryptoTransform,
                CryptoStreamMode.Read
            );
            using StreamReader reader = new StreamReader(cryptoStream);

            string result = reader.ReadToEnd();

            // Display the decrypted result for debugging purposes.
            Debug.Log($"Decrypted result (if the following is not legible, probably wrong key or iv): {result}");

            // Deserialize the decrypted data and return it.
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
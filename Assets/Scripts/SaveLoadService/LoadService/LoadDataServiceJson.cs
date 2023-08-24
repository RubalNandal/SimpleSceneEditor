using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using RubalNandal.SaveLoadService.Encryption;

namespace RubalNandal.SaveLoadService.LoadService
{
    /// <summary>
    /// A data loading service that loads data from JSON files, with optional encryption support.
    /// </summary>
    public class LoadDataServiceJson : ILoadDataService
    {
        // Instance of ReadEncryptedDataFromFile to handle encrypted data reading.
        ReadEncryptedDataFromFile readEncryptedDataFromFile =  new ReadEncryptedDataFromFile();

        /// <summary>
        /// Loads data of type T from the specified relative path.
        /// </summary>
        /// <typeparam name="T">The type of data to be loaded.</typeparam>
        /// <param name="RelativePath">The relative path to the data file.</param>
        /// <param name="Encrypted">Indicates whether the data is encrypted.</param>
        /// <returns>The loaded data of type T.</returns>
        public T LoadData<T>(string RelativePath, bool Encrypted)
        {
            // Get the absolute path to the data file.
            string path = Application.persistentDataPath + RelativePath;

            // Check if the file exists at the specified path.
            if (!File.Exists(path))
            {
                Debug.LogError($"Cannot load file at {path}. File does not exist!");
                throw new FileNotFoundException($"{path} does not exist!");
            }

            try
            {
                T data;
                if (Encrypted)
                {
                    // Load encrypted data using the ReadEncryptedDataFromFile instance.
                    data = readEncryptedDataFromFile.ReadEncryptedData<T>(path);
                }
                else
                {
                    // Load encrypted data using the ReadEncryptedDataFromFile instance.
                    data = JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                }
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
                throw e;
            }
        }
    }
}

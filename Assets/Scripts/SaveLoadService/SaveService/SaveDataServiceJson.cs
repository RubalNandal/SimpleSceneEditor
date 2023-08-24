using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using RubalNandal.SaveLoadService.Encryption;

namespace RubalNandal.SaveLoadService.SaveService
{
    /// <summary>
    /// A data saving service that saves data to JSON files, with optional encryption support.
    /// </summary>
    public class SaveDataServiceJson : ISaveDataService
    {
        /// <summary>
        /// Saves data of type T to the specified relative path.
        /// </summary>
        /// <typeparam name="T">The type of data to be saved.</typeparam>
        /// <param name="RelativePath">The relative path to save the data file.</param>
        /// <param name="Data">The data to be saved.</param>
        /// <param name="Encrypted">Indicates whether the data should be encrypted.</param>
        /// <returns>True if the data was successfully saved, otherwise false.</returns>
        public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
        {
            // Instance of WriteEncryptedDataToFile to handle encrypted data writing.
            WriteEncryptedDataToFile writeEncryptedDataToFile = new WriteEncryptedDataToFile();

            string path = Application.persistentDataPath + RelativePath;

            try
            {
                if (File.Exists(path))
                {
                    Debug.Log("Data exists. Deleting old file and writing a new one!");
                    File.Delete(path);
                }
                else
                {
                    Debug.Log("Writing file for the first time!");
                }

                using FileStream stream = File.Create(path);

                if (Encrypted)
                {
                    writeEncryptedDataToFile.WriteEncryptedData(Data, stream);
                }
                else
                {
                    stream.Close();
                    File.WriteAllText(path, JsonConvert.SerializeObject(Data));
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
                return false;
            }
        }

        
        

        
    }

}

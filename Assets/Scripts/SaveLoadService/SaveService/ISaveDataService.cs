
namespace RubalNandal.SaveLoadService.SaveService
{
    /// <summary>
    /// Interface for defining a data saving service, capable of saving data of type T to a file.
    /// </summary>
    public interface ISaveDataService
    {
        /// <summary>
        /// Saves data of type T to the specified relative path.
        /// </summary>
        /// <typeparam name="T">The type of data to be saved.</typeparam>
        /// <param name="RelativePath">The relative path to save the data file.</param>
        /// <param name="Data">The data to be saved.</param>
        /// <param name="Encrypted">Indicates whether the data should be encrypted.</param>
        /// <returns>True if the data was successfully saved, otherwise false.</returns>
        bool SaveData<T>(string RelativePath, T Data, bool Encrypted);

        
    }
}

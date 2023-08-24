
namespace RubalNandal.SaveLoadService.LoadService
{
    /// <summary>
    /// Interface for defining a data loading service, capable of loading data of type T from a file.
    /// </summary>
    public interface ILoadDataService 
    {
        /// <summary>
        /// Loads data of type T from the specified relative path.
        /// </summary>
        /// <typeparam name="T">The type of data to be loaded.</typeparam>
        /// <param name="RelativePath">The relative path to the data file.</param>
        /// <param name="Encrypted">Indicates whether the data is encrypted.</param>
        /// <returns>The loaded data of type T.</returns>
        T LoadData<T>(string RelativePath, bool Encrypted);
    }
}
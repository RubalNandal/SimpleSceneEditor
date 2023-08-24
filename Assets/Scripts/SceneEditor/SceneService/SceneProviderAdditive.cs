using UnityEngine;
using UnityEngine.SceneManagement;

namespace RubalNandal.SceneEditor.SceneService
{
    /// <summary>
    /// Loads a scene additively using the ISceneProvider interface.
    /// </summary>
    public class SceneProviderAdditive : MonoBehaviour, ISceneProvider
    {
        /// <summary>
        /// The name of the scene to be loaded.
        /// </summary>
        [SerializeField]
        public string sceneName;

        /// <summary>
        /// Start the scene loading process on Start.
        /// </summary>
        private void Start()
        {
            LoadScene();  
        }

        /// <summary>
        /// Load the specified scene additively.
        /// </summary>
        public void LoadScene()
        {
            // Check if the scene is already loaded before loading it additively
            if (!SceneManager.GetSceneByName(sceneName).isLoaded)
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

    }
}
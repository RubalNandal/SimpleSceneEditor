using UnityEngine;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SceneEditor.Environment;

namespace RubalNandal.SceneEditor.Commands
{
    /// <summary>
    /// Command for spawning a game object in the scene.
    /// </summary>
    [System.Serializable]
    public class SpawnCommand : ICommand
    {

        GameObject _spawnedGameObject;

        /// <summary>
        /// The type of the command (spawn).
        /// </summary>
        public string commandType { get => ENV_CONSTANTS.COMMAND_TYPE.SPAWN; }

        /// <summary>
        /// Index of the spawnable object in the scene.
        /// </summary>
        public int spawnableObjectIndex { get; }

        /// <summary>
        /// Position at which the object is spawned.
        /// </summary>
        public Vector3 spawnPosition { get; }

        /// <summary>
        /// Creates a new SpawnCommand.
        /// </summary>
        /// <param name="spawnPosition">Position at which the object is spawned.</param>
        /// <param name="spawnPrefeb">Prefab of the object to be spawned.</param>
        /// <param name="spawnableObjectIndex">Index of the spawnable object in the spawanabled object static list.</param>
        public SpawnCommand(Vector3 spawnPosition , GameObject spawnPrefeb , int spawnableObjectIndex)
        {
            this.spawnPosition = spawnPosition;
            this.spawnableObjectIndex = spawnableObjectIndex;
            _spawnedGameObject = GameObject.Instantiate(spawnPrefeb, spawnPosition, Quaternion.identity);
        }

        /// <summary>
        /// Activates the spawned object.
        /// </summary>
        public void Execute()
        {
            _spawnedGameObject.SetActive(true);
        }

        /// <summary>
        /// Deactivates the spawned object.
        /// </summary>
        public void Undo()
        {
            _spawnedGameObject.SetActive(false);
        }

       

    }

}

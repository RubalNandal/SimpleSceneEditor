using UnityEngine;
using RubalNandal.DesignPattern.EventSystem;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SceneEditor.Commands;

namespace RubalNandal.SceneEditor.SpawnSystem
{
    /// <summary>
    /// Spawns primitive objects using spawn events.
    /// </summary>
    public class SpawnPrimitive : MonoBehaviour
    {
        /// <summary>
        /// The GameEventSO used to raise spawn events.
        /// </summary>
        public GameEventSO spawnEvent;

        /// <summary>
        /// The ScriptableObject containing data about spawnable objects.
        /// </summary>
        public SpawnableObjectsSO spawnableObjects;

        /// <summary>
        /// Spawns a primitive object based on the received spawn event data.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="data">The data associated with the event (spawnObjectIndex).</param>
        public void SpawnPrimitiveObject(Component sender , object data)
        {
            int spawnObjectIndex = (int)data;
            GameObject prefab = spawnableObjects.spawnables[spawnObjectIndex].prefeb;
            ICommand command = new SpawnCommand(GetRandomPosition(), prefab, spawnObjectIndex);
            spawnEvent.Raise(this, command);
        }

        /// <summary>
        /// Generates a random position for spawning the primitive object.
        /// </summary>
        /// <returns>A random spawn position.</returns>
        Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(-10,10),1.2f,Random.Range(-10,10));
        }
    }

}

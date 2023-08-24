using UnityEngine;
using RubalNandal.DesignPattern.EventSystem;

namespace RubalNandal.SceneEditor.SpawnSystem
{
    /// <summary>
    /// Generates and raises spawn events for a specific spawnable object.
    /// </summary>
    public class SpawnEventGenerator : MonoBehaviour
    {
        /// <summary>
        /// Index of the spawnable object to be used in the spawn event.
        /// </summary>
        public int spawnObjectIndex = -1;

        /// <summary>
        /// The GameEventSO used to raise spawn events.
        /// </summary>
        public GameEventSO spawnEvent;

        /// <summary>
        /// Raise the spawn event with the specified spawnObjectIndex.
        /// </summary>
        public void RaiseEvent()
        {
            spawnEvent.Raise(this, spawnObjectIndex);
        }

    }

}

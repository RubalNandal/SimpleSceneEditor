using System;
using System.Collections.Generic;
using UnityEngine;

namespace RubalNandal.SceneEditor.SpawnSystem
{
    /// <summary>
    /// ScriptableObject containing a list of spawnable objects' data.
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObjects/Spawnable")]
    public class SpawnableObjectsSO : ScriptableObject
    {
        /// <summary>
        /// List of spawnable objects' data.
        /// </summary>
        public List<SpawnableData> spawnables = new List<SpawnableData>();
    }

    /// <summary>
    /// Struct representing the data of a spawnable object.
    /// </summary>
    [Serializable]
    public struct SpawnableData
    {
        public int id;
        public string spawnableName;
        public GameObject prefeb;
    }
}

    
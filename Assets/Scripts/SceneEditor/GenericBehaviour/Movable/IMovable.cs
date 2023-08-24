using System.Collections.Generic;
using UnityEngine;


namespace RubalNandal.SceneEditor.GenericBehaviour
{
    /// <summary>
    /// Interface for making objects movable and tracking their movement state.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// The current position of the movable object.
        /// </summary>
        Vector3 _position { get; set; }

        /// <summary>
        /// List of movable objects in the scene.
        /// </summary>
        public static List<IMovable> movableObjects = new List<IMovable>();

    }
}
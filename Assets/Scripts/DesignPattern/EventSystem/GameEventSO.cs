using System;
using System.Collections.Generic;
using UnityEngine;

namespace RubalNandal.DesignPattern.EventSystem
{
    /// <summary>
    /// ScriptableObject representing a game event that can be listened to and raised.
    /// </summary>
    [CreateAssetMenu(menuName = "GameEvent")]
    public class GameEventSO : ScriptableObject
    {
        /// <summary>
        /// List of listeners that have registered for this event.
        /// </summary>
        public List<GameEventListener> listeners = new List<GameEventListener>();

        /// <summary>
        /// Raises the event, notifying all registered listeners.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="data">Optional data associated with the event.</param>
        public void Raise(Component sender , object data)
        {
            foreach(GameEventListener listener in listeners)
            {
                listener.OnEventRaised(sender,data);
            }
        }




        /// <summary>
        /// Raises the event, notifying all registered listeners.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="data">Optional data associated with the event.</param>
        public void RegisterListener(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        /// <summary>
        /// Unregisters a listener from this event.
        /// </summary>
        /// <param name="listener">The listener to be unregistered.</param>
        public void UnregisterListener(GameEventListener listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }

    }
}

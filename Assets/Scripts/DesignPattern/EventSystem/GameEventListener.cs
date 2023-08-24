using UnityEngine;
using UnityEngine.Events;

namespace RubalNandal.DesignPattern.EventSystem
{
    /// <summary>
    /// A custom UnityEvent type that accepts a Component sender and object data as parameters.
    /// </summary>
    [System.Serializable]
    public class CustomGameEvent : UnityEvent<Component, object> { }

    /// <summary>
    /// A MonoBehaviour that listens to a GameEventSO and invokes a response when the event is raised.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
        /// <summary>
        /// The GameEventSO that this listener is attached to.
        /// </summary>
        public GameEventSO gameEvent;

        /// <summary>
        /// The custom UnityEvent response to be invoked when the event is raised.
        /// </summary>
        public CustomGameEvent response;

        private void OnEnable()
        {
            // Register this listener with the GameEventSO when this GameObject is enabled.
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            // Unregister this listener from the GameEventSO when this GameObject is disabled.
            gameEvent.UnregisterListener(this);
        }


        /// <summary>
        /// Invoked when the attached GameEventSO is raised.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="data">Optional data associated with the event.</param>
        public void OnEventRaised(Component sender , object data)
        {
            response.Invoke(sender,data);
        }




    }


}

using UnityEngine;

namespace RubalNandal.DesignPattern.EventSystem
{
    /// <summary>
    /// A MonoBehaviour that can be used to raise null events by utilizing a GameEventSO.
    /// </summary>
    public class GenericEventRaiser : MonoBehaviour
    {
        /// <summary>
        /// The GameEventSO instance representing the generic event to be raised.
        /// </summary>
        public GameEventSO genericEvent;

        /// <summary>
        /// Raises a null event using the associated GameEventSO.
        /// </summary>
        public void RaiseNullEvent()
        {
            genericEvent.Raise(this, null);
        }
    }
}

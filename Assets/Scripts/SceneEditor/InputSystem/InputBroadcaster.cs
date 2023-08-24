using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using RubalNandal.DesignPattern.EventSystem;

namespace RubalNandal.SceneEditor.InputSystem
{
    /// <summary>
    /// Broadcasts input events to the relevant game events.
    /// </summary>
    public class InputBroadcaster : MonoBehaviour
    {

        [SerializeField] private GameEventSO primitiveItemZoomEvent;
        [SerializeField] private GameEventSO cameraLookEvent;
        [SerializeField] private GameEventSO cameraMoveEvent;

        /// <summary>
        /// Called when the primitive item zoom input is triggered.
        /// </summary>
        public void OnPrimitiveItemZoom(InputAction.CallbackContext input)
        {
            primitiveItemZoomEvent.Raise(this, input.ReadValue<float>());
        }

        /// <summary>
        /// Called when the camera look input is triggered.
        /// </summary>
        public void OnCameraLookEvent(InputAction.CallbackContext input)
        {
            Vector2 lookInput = input.ReadValue<Vector2>();

            cameraLookEvent.Raise(this, lookInput);
        }

        /// <summary>
        /// Called when the camera move input is triggered.
        /// </summary>
        public void OnCameraMoveEvent(InputAction.CallbackContext input)
        {
            Vector2 moveInput = input.ReadValue<Vector2>();

            cameraMoveEvent.Raise(this, moveInput);
        }
    }

}

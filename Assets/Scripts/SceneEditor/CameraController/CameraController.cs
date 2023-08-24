using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace RubalNandal.SceneEditor.CameraController
{
    /// <summary>
    /// Controls the behavior of the camera in the scene.
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        Vector2 _cameraLookInput = new Vector2();
        Vector2 _cameraMoveInput = new Vector2();

        float _cameraYawValue;
        float _cameraPitchValue;

        [Header("Controller Sensitivity Values")]
        public float moveSpeed = 5f;
        public float mouseRotationSpeed = 5f;

        [Header("Layers to ignore for Click")]
        public LayerMask layersToIgnore;

        bool _lockCameraLook = true;

        /// <summary>
        /// Updates the camera look input based on the event data.
        /// </summary>
        public void UpdateCameraLookInput(Component sender, object data)
        {
            _cameraLookInput = (Vector2)data;
        }

        /// <summary>
        /// Updates the camera move input based on the event data.
        /// </summary>
        public void UpdateCameraMoveInput(Component sender, object data)
        {
            _cameraMoveInput = (Vector2)data;
        }

        private void Update()
        {
            if (Pointer.current.press.wasPressedThisFrame && CheckClickableObject())
            {
                _lockCameraLook = false;
            }
            if (Pointer.current.press.wasReleasedThisFrame)
            {
                _lockCameraLook = true;
            }
            
            CameraMovement();

            //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }


        /// <summary>
        /// Checks if the mouse is over an object that should not block camera movement.
        /// </summary>
        bool CheckClickableObject()
        {
            if(EventSystem.current.currentSelectedGameObject is not null)
            {
                return false;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast with the specified layer mask
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity , layersToIgnore))
            {
                return false;
            }
            
            return true;
            
        }


        private void LateUpdate()
        {
            CameraRotation();
        }

        /// <summary>
        /// controls camera rotation
        /// </summary>
        private void CameraRotation()
        {
            if (_cameraLookInput.sqrMagnitude >= 0.1 && !_lockCameraLook)
            {
                _cameraYawValue += _cameraLookInput.x * Time.deltaTime * mouseRotationSpeed;
                _cameraPitchValue += _cameraLookInput.y * Time.deltaTime * mouseRotationSpeed;
            }

            // Clamp mouse the movement
            _cameraYawValue = Mathf.Clamp(_cameraYawValue, float.MinValue, float.MaxValue);
            _cameraPitchValue = Mathf.Clamp(_cameraPitchValue, -10, 70);

            // Rotate the Camera follow target
            transform.transform.rotation = Quaternion.Euler(_cameraPitchValue, _cameraYawValue, 0.0f);
        }

        /// <summary>
        /// Controls camera movement based on input.
        /// </summary>
        private void CameraMovement()
        {
            Vector3 movement = new Vector3(_cameraMoveInput.x , 0 , _cameraMoveInput.y) * moveSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
    }
}


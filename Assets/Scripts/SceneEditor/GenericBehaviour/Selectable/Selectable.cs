using UnityEngine;
using UnityEngine.EventSystems;
using RubalNandal.DesignPattern.EventSystem;
using RubalNandal.SceneEditor.Commands;

namespace RubalNandal.SceneEditor.GenericBehaviour
{
    /// <summary>
    /// Component to make a GameObject selectable and handle selection events.
    /// </summary>
    [RequireComponent(typeof(MeshRenderer))]
    public class Selectable : MonoBehaviour, ISelectable , IPointerDownHandler
    {
        /// <summary>
        /// The MeshRenderer component of the selectable object.
        /// </summary>
        public MeshRenderer meshRenderer { get; private set; }

        /// <summary>
        /// Event to raise when the object is selected.
        /// </summary>
        public GameEventSO selectEvent;

        /// <summary>
        /// The default color of the object before being selected.
        /// </summary>
        public Color defaultColor { get; private set; }
        private int _currentObjectIndex = -1;

        void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            defaultColor = meshRenderer.material.color;
            
        }

        private void OnEnable()
        {
            _currentObjectIndex = ISelectable.selectableObjects.Count;
            ISelectable.selectableObjects.Add(this);
        }

        /// <summary>
        /// Handles the pointer down event to select the object.
        /// </summary>
        public void OnPointerDown(PointerEventData eventData)
        {
            if(_currentObjectIndex != ISelectable.currentSelectedObjectIndex)
            {
                // Create a SelectCommand and raise the select event
                SelectCommand _selectCommand = new SelectCommand(meshRenderer, defaultColor, _currentObjectIndex);
                selectEvent.Raise(this, _selectCommand);
                ISelectable.currentSelectedObjectIndex = _currentObjectIndex;
            }
            
        }
        private void OnDisable()
        {
            _currentObjectIndex = -1;
            ISelectable.selectableObjects.Remove(this);
        }


    }
}
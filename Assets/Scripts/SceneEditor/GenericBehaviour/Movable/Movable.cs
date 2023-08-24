using UnityEngine;
using UnityEngine.EventSystems;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.DesignPattern.EventSystem;
using RubalNandal.SceneEditor.Commands;

namespace RubalNandal.SceneEditor.GenericBehaviour
{
    /// <summary>
    /// Component to make a GameObject movable and handle movement events.
    /// </summary>
    public class Movable : MonoBehaviour, IMovable , IDragHandler, IDropHandler 
    {

        [SerializeField]private GameEventSO _moveCommandEvent;

        /// <summary>
        /// The current position of the movable object.
        /// </summary>
        public Vector3 _position { get; set; }
        private float _posz = 0;
        private bool _isdraging = false;
        private float _primitiveItemZoomInputValue;
        private Vector3 _initalPosition, _finalPosition;
        public int movableIndex = -1;
        [SerializeField] private float zoomMultilpier = 0.5f;



        // updates the zoom action input (from keyboard (z/x) or mouse scroll) , through event
        public void UpdateInputValue(Component sender , object data)
        {
            _primitiveItemZoomInputValue = (float)data;
        }

        private void OnEnable()
        {
            movableIndex = IMovable.movableObjects.Count;
            IMovable.movableObjects.Add(this);
        }

        
        public void OnDrag(PointerEventData eventData)
        {
            // set initial position of primitive
            if (!_isdraging)
            {
                _initalPosition = transform.position;
                _posz = Mathf.Abs( (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).z);
            }

            _isdraging = true;
            
        }     

        public void OnDrop(PointerEventData eventData)
        {
            _isdraging = false;

            // call move command 
            MoveObject(_initalPosition, _finalPosition, transform, movableIndex);

        }


        /// <summary>
        /// Moves the object to the specified position using a move command.
        /// </summary>
        public void MoveObject(Vector3 initialPosition ,  Vector3 finalPosition , Transform transform , int movableIndex)
        {
            ICommand _moveCommand = new MoveCommand(initialPosition, finalPosition, transform, movableIndex);
            _moveCommandEvent.Raise(this, _moveCommand);
        }

        private void OnDisable()
        {
            movableIndex = -1;
            IMovable.movableObjects.Remove(this);
        }

        private void Update()
        {
            if (_isdraging)
            {
                _posz = _posz + _primitiveItemZoomInputValue * zoomMultilpier;
                _finalPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _posz);
                _finalPosition = Camera.main.ScreenToWorldPoint(_finalPosition);
                transform.position = _finalPosition;
            }
                
        }

    }
}
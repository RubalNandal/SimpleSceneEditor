using UnityEngine;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SceneEditor.Environment;

namespace RubalNandal.SceneEditor.Commands
{
    /// <summary>
    /// Command for moving a game object in the scene.
    /// </summary>
    [System.Serializable]
    public class MoveCommand : ICommand
    {
        /// <summary>
        /// The initial position of the game object before the move.
        /// </summary>
        public Vector3 initialPosition { get; }

        /// <summary>
        /// The final position of the game object after the move.
        /// </summary>
        public Vector3 finalPosition { get; }

        /// <summary>
        /// Index of the movable object.
        /// </summary>
        public int movableIndex { get; }

        // The transform component of the game object.
        Transform _componentTransform;

        /// <summary>
        /// The type of the command (move).
        /// </summary>
        public string commandType { get => ENV_CONSTANTS.COMMAND_TYPE.MOVE; }

        /// <summary>
        /// Creates a new MoveCommand.
        /// </summary>
        /// <param name="initialPosition">The initial position of the game object before the move.</param>
        /// <param name="finalPosition">The final position of the game object after the move.</param>
        /// <param name="componentTransform">The transform component of the game object.</param>
        /// <param name="movableIndex">Index of the movable object.</param>
        public MoveCommand(Vector3 initialPosition, Vector3 finalPosition, Transform componentTransform, int movableIndex)
        {
            this.initialPosition = initialPosition;
            this.finalPosition = finalPosition;
            _componentTransform = componentTransform;
            this.movableIndex = movableIndex;
        }

        /// <summary>
        /// Executes the move by updating the game object's position.
        /// </summary>
        public void Execute()
        {
            _componentTransform.position = finalPosition;
        }

        /// <summary>
        /// Reverts the move by restoring the game object's initial position.
        /// </summary>
        public void Undo()
        {
            _componentTransform.position = initialPosition;
        }

        

    }
}

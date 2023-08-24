using UnityEngine;

namespace RubalNandal.DesignPattern.CommandPattern
{
    /// <summary>
    /// A MonoBehaviour that acts as a command scheduler, providing a way to interact
    /// with a CommandHandler to add, undo, and redo commands.
    /// </summary>
    public class CommandScheduler : MonoBehaviour
    {
        /// <summary>
        /// The CommandHandler instance responsible for managing commands and history.
        /// </summary>
        public CommandHandler commandHandler;

        /// <summary>
        /// Adds a command to the command history using the CommandHandler.
        /// </summary>
        /// <param name="sender">The sender or source of the command.</param>
        /// <param name="command">The command object to be added.</param>

        public void AddCommand(Component sender, object command)
        {
            commandHandler.AddCommand((ICommand)command);
        }

        /// <summary>
        /// Undoes the last executed command using the CommandHandler.
        /// </summary>
        public void UndoCommand()
        {
            commandHandler.UndoCommand();
        }

        /// <summary>
        /// Redoes the last undone command using the CommandHandler.
        /// </summary>
        public void RedoCommand()
        {
            commandHandler.RedoCommand();
        }

        /// <summary>
        /// Resets the command history when the GameObject is destroyed.
        /// </summary>
        private void OnDestroy()
        {
            commandHandler.Reset();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RubalNandal.DesignPattern.CommandPattern
{
    /// <summary>
    /// A ScriptableObject class that manages commands, undo/redo functionality,
    /// and maintains a list of executed commands.
    /// </summary>
    [CreateAssetMenu(menuName ="CommandHandler")]
    public class CommandHandler : ScriptableObject
    {
        /// <summary>
        /// List to store the executed commands.
        /// </summary>
        [SerializeReference]  List<ICommand> commandList = new List<ICommand>();

        /// <summary>
        /// Index indicating the position of the last executed command.
        /// </summary>
        [SerializeField] public int index { get; private set; }


        /// <summary>
        /// Adds a new command to the command list, executes it, and increments the index.
        /// </summary>
        /// <param name="command">The command to be added and executed.</param>

        public void AddCommand(ICommand command)
        {
            // Remove any future commands (redo history) if a new command is added.

            if (index < commandList.Count)
            {
                commandList.RemoveRange(index, commandList.Count - index);
            }

            // Add the new command, execute it, and update the index.
            commandList.Add(command);
            command.Execute();
            index++;
 
            
        }

        /// <summary>
        /// Undoes the last executed command and updates the index accordingly.
        /// </summary>
        public void UndoCommand()
        {
            if (commandList.Count <= 0)
                return;

            if (index > 0)
            {
                commandList[index - 1].Undo();
                index--;
            }
        }

        /// <summary>
        /// Redoes the next command in the history and updates the index accordingly.
        /// </summary>
        public void RedoCommand()
        {
            if(commandList.Count == 0)
            {
                return;
            }

            if (index < commandList.Count)
            {
                index++;
                commandList[index - 1].Execute();
            }
        }


        /// <summary>
        /// Resets the command list and index.
        /// </summary>
        public void Reset()
        {
            commandList = null;
            index = 0;
        }


        /// <summary>
        /// Clears the entire scene by undoing all executed commands
        /// and resetting the list and index.
        /// </summary>
        public void ClearScene()
        {
            for(int i = index;i >0;i--)
            {
                UndoCommand();
            }
            commandList = new List<ICommand>();
            index = 0;
        }
    }
}

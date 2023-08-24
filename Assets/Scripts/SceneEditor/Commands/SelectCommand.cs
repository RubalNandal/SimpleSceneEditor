using UnityEngine;
using RubalNandal.DesignPattern.CommandPattern;
using System.Collections.Generic;
using RubalNandal.SceneEditor.Environment;

namespace RubalNandal.SceneEditor.Commands
{
    /// <summary>
    /// Command for selecting a game object in the scene.
    /// </summary>
    [System.Serializable]
    public class SelectCommand : ICommand
    {
        // Static list to keep track of selected objects.
        static List<SelectCommand> selectedobjects = new List<SelectCommand>();
        static int index;

        /// <summary>
        /// The type of the command (select).
        /// </summary>
        public string commandType { get => ENV_CONSTANTS.COMMAND_TYPE.SELECT; }

        // The mesh renderer of the selected object.
        public MeshRenderer _meshRenderer;

        // The default color of the selected object.
        public Color _defaultColor;

        // Index of the selected object.
        public int _selectIndex;

        // The color to indicate selection.
        private Color _selectedColor = Color.yellow;

        /// <summary>
        /// Creates a new SelectCommand.
        /// </summary>
        /// <param name="meshRenderer">The mesh renderer of the selected object.</param>
        /// <param name="defaultColor">The default color of the selected object.</param>
        /// <param name="selectIndex">Index of the selected object.</param>
        public SelectCommand(MeshRenderer meshRenderer, Color defaultColor, int selectIndex)
        {
            _selectIndex = selectIndex;
            _meshRenderer = meshRenderer;
            _defaultColor = defaultColor;

            // to prevent duplicate select commands
            if (selectedobjects.Count < 1 || !selectedobjects[selectedobjects.Count - 1].Equals(this))
            {
                // if index is not at he last element while adding new command then remove the commands in between
                if (index < selectedobjects.Count)
                {
                    selectedobjects.RemoveRange(index, selectedobjects.Count - index);
                }

                selectedobjects.Add(this);
            }
            
        }

        /// <summary>
        /// Executes the selection by changing the color.
        /// </summary>
        public void Execute()
        {
            

            // reset colour of previously selected object
            if (index > 0)
            {
                selectedobjects[index - 1]._meshRenderer.material.color = selectedobjects[index - 1]._defaultColor;
            }

            // Change the color of the currently selected object.
            _meshRenderer.material.color = _selectedColor;

            index++;
        }

        /// <summary>
        /// Reverts the selection by changing the color back.
        /// </summary>
        public void Undo()
        {
            
            // set colour of previously selected object
            if (index > 1)
            {
                selectedobjects[index - 2]._meshRenderer.material.color = selectedobjects[index - 2]._selectedColor;
            }

            // Change the color of the currently unselected object.
            _meshRenderer.material.color = _defaultColor;


            index--;

            
        }


        

    }
}

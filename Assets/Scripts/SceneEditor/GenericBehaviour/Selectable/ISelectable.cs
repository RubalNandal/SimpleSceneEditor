using System.Collections.Generic;


namespace RubalNandal.SceneEditor.GenericBehaviour
{
    /// <summary>
    /// Interface for making objects selectable and tracking their selection state.
    /// </summary>
    public interface ISelectable
    {
        /// <summary>
        /// Index of the currently selected object (-1 if no object is selected).
        /// </summary>
        public static int currentSelectedObjectIndex = -1;

        /// <summary>
        /// List of selectable objects in the scene.
        /// </summary>
        public static List<ISelectable> selectableObjects = new List<ISelectable>();
    }
}
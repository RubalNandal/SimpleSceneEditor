namespace RubalNandal.SceneEditor.Environment
{
    /// <summary>
    /// Constants related to the scene editor environment.
    /// </summary>
    public class ENV_CONSTANTS
    {
        /// <summary>
        /// Relative path for saving files.
        /// </summary>
        public const string SAVE_PATH = "\\saveFile";

        /// <summary>
        /// Types of commands used in the scene editor.
        /// </summary>
        public static class COMMAND_TYPE
        {
            public const string SELECT = "Select";
            public const string MOVE = "Move";
            public const string SPAWN = "Spawn";
        }
    }
}


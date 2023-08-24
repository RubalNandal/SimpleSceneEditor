
namespace RubalNandal.DesignPattern.CommandPattern
{
    /// <summary>
    /// Interface for defining commands that can be executed and undone.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets a string describing the type of the command.
        /// </summary>
        string commandType { get;}

        /// <summary>
        /// Executes the command.
        /// </summary>
        void Execute();

        /// <summary>
        /// Undoes the effects of the executed command.
        /// </summary>
        void Undo();


    }
}

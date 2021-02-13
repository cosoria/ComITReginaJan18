using DomainLayer;
using DomainLayer.Commands;

namespace ConsoleUI
{
    class CommandParser
    {
        internal ICommand Parse(string commandString)
        {
            if (string.IsNullOrWhiteSpace(commandString))
            {
                return null;
            }

            ICommand command = null;

            commandString = commandString.ToLowerInvariant();
            
            if (commandString.StartsWith("exit"))
            {
                command = new ExitCommand();
            }

            if (commandString.StartsWith("list"))
            {
                command = new ListCommand();
            }

            if (commandString.StartsWith("take"))
            {
                command = new TakeCommand();
            }

            if (command != null)
            {
                command.Init(commandString);
            }
            
            return command;
        }
    }
}
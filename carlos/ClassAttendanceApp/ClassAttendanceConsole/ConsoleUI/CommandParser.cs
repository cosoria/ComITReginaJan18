using System;
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
            
            commandString = commandString.ToLowerInvariant();

            var cmdParams = commandString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var command = CommandFactory.Create(cmdParams[0]);
            
            if (command != null)
            {
                command.Init(cmdParams);
            }
            
            return command;
        }
    }
}
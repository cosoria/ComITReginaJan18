using System;
using DomainLayer.Commands;
using DomainLayer.Contracts;

namespace ConsoleUI
{
    internal class CommandParser
    {
        internal ICommand Parse(string commandString)
        {
            if (string.IsNullOrWhiteSpace(commandString))
            {
                return new NoCommand();
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
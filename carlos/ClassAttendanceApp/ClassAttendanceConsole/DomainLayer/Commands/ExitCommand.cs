using System;
using System.Collections.Generic;
using DomainLayer.Contracts;

namespace DomainLayer.Commands
{
    public class ExitCommand : ICommand
    {
        public void Init(string[] commandParameters)
        {
        }

        public string GetHelpText()
        {
            return 
@"      Overview: 
            exit: Exits the program
        
        Usage:
            exit 

        Example:
            :> exit
";
        }

        public CommandResult Execute()
        {
            return CommandResult.ExitResult();
        }
    }
}

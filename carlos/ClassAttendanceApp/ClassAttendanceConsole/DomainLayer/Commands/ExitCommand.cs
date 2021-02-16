using System;
using System.Collections.Generic;

namespace DomainLayer.Commands
{
    public class ExitCommand : CommandBase
    {
        
        public override string GetHelpText()
        {
            return 
@"      Usage: 
            exit : Exits the program
";
        }

        public override CommandResult Execute()
        {
            return CommandResult.ExitResult();
        }
    }
}

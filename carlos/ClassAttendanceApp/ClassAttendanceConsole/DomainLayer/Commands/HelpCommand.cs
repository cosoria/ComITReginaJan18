using System;
using DomainLayer.Contracts;

namespace DomainLayer.Commands
{
    public class HelpCommand : CommandBase
    {
        public override CommandResult Execute()
        {
            var specificCommand = _entityType;

            if (!string.IsNullOrWhiteSpace(specificCommand))
            {
                var command = GetCommand(specificCommand);

                Console.WriteLine(command.GetHelpText());

                return CommandResult.OkResult();
            }

            Console.WriteLine(_helpText);

            return CommandResult.OkResult();
        }

        private ICommand GetCommand(string commandName)
        {
            return CommandFactory.Create(commandName);
        }

        public override string GetHelpText()
        {
            return
                @"      Overview:
            Display command help for system or for specific commands
        
        Usage:
            help <command>
            <command>: is any of the available commands

        Example:
            :> help         : displays general help
            :> help list    : displays the help for the list command
";
        }

        private string _helpText =
@"
    Welcome to ComIT Course Management App {0}

    The following commands are available:

    - help: display command help you can use 'help <command>' for more specific help
    - exit: exits the program 
    - list: display information use 'help list' for detail help
    - attendance: use to take class attendance

    Use the help command to discover specific usage of any command
    Example:
        :> help list 
";
    }
}
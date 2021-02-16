using System;

namespace DomainLayer.Commands
{
    public class HelpCommand : CommandBase
    {
        private string subCommand = string.Empty; 
        public override string GetHelpText()
        {
            return
@"      Usage:
            help <command>: displays specific command help topics
";
        }

        public override void Init(string[] commandParameters)
        {
            this.subCommand = string.Empty;

            if (string.IsNullOrWhiteSpace(commandParameters[1]))
            {
                return;
            }

            subCommand = commandParameters[1];
        }

        public override CommandResult Execute()
        {
            if (!string.IsNullOrWhiteSpace(subCommand))
            {
                var command = GetCommand(subCommand);

                Console.WriteLine(command.GetHelpText());

                return CommandResult.OkResult();
            }

            Console.WriteLine(_helpText);

            return CommandResult.OkResult();
        }

        private ICommand GetCommand(string commandText)
        {
            return CommandFactory.Create(commandText);
        }

        private string _helpText =
@"
    Welcome to ComIT Course Management App {0}

    The following commands are available for you 
    - help: display command help you can use 'help <command>' for more specific help
    - exit: exits the program 
    - list: display information use 'help list' for detail help
    - take: use to take class attendance, use <help take> for detail help  
";
    }
}
using System;

namespace DomainLayer.Commands
{
    public class HelpCommand : ICommand
    {
        public void Init(string commandParameters)
        {
        }

        public string GetHelpText()
        {
            return
@"      Usage:
            help <command>: displays specific command help topics
";
        }

        public CommandResult Execute()
        {
            Console.WriteLine(_helpText);
            return CommandResult.OkResult();
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
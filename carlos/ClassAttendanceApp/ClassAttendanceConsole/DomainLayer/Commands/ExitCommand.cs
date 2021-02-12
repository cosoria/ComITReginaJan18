namespace DomainLayer.Commands
{
    public class ExitCommand : ICommand
    {
        public void Init(string commandParameters)
        {
        }

        public string GetHelpText()
        {
            return 
@"      Usage: 
            exit : Exits the program
";
        }

        public CommandResult Execute()
        {
            return CommandResult.ExitResult();
        }
    }
}

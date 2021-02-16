namespace DomainLayer.Commands
{
    public class ErrorCommand : ICommand
    {
        public void Init(string[] commandParameters)
        {
        }

        public string GetHelpText()
        {
            return "ERROR: Command was not found";
        }

        public CommandResult Execute()
        {
            return CommandResult.ErrorResult("ERROR: Command not found");
        }
    }
}
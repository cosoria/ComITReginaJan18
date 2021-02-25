using DomainLayer.Contracts;

namespace DomainLayer.Commands
{
    public class NoCommand : ICommand
    {
        public void Init(string[] commandParameters)
        {
        }

        public string GetHelpText()
        {
            return string.Empty;
        }

        public CommandResult Execute()
        {
            return CommandResult.ErrorResult("This is not a command");
        }
    }
}
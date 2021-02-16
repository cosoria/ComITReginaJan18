namespace DomainLayer.Commands
{
    public class TakeCommand : ICommand
    {
        public void Init(string[] commandParameters)
        {
        }

        public string GetHelpText()
        {
            return 
@"      Usage:
            take class      : take attendance for the class 
            take student <#>: take attendance for student with # 
            take student <name>
";
        }

        public CommandResult Execute()
        {
            return CommandResult.OkResult();
        }
    }
}
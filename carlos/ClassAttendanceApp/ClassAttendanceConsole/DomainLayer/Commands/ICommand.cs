namespace DomainLayer.Commands
{
    public interface ICommand
    {
        void Init(string commandParameters);
        string GetHelpText();
        CommandResult Execute();
    }
}
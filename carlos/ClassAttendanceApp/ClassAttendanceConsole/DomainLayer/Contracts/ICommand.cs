using DomainLayer.Commands;

namespace DomainLayer.Contracts
{
    public interface ICommand
    {
        void Init(string[] commandParameters);
        string GetHelpText();
        CommandResult Execute();
    }
}
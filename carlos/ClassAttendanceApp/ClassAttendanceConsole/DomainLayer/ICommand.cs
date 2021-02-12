using System;

namespace DomainLayer
{
    public interface ICommand
    {
        void Init(string commandParameters);
        string GetHelpText();
        CommandResult Execute();
    }
}
using System;

namespace DomainLayer.Commands
{
    public abstract class CommandBase : ICommand
    {
        public virtual void Init(string[] commandParameters)
        {
        }

        public virtual string GetHelpText()
        {
            return string.Empty;
        }

        public virtual CommandResult Execute()
        {
            return CommandResult.OkResult();
        }
    }
}
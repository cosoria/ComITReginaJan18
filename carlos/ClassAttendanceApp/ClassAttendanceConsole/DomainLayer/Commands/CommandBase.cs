using System;
using DomainLayer.Contracts;

namespace DomainLayer.Commands
{
    public abstract class CommandBase : ICommand
    {
        protected string _command;
        protected string _entityType;
        protected int _id;

        public virtual void Init(string[] commandParameters)
        {
            _command = commandParameters[0];
            _entityType = string.Empty;

            if (commandParameters.Length < 2)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(commandParameters[1]))
            {
                _entityType = commandParameters[1];
            }

            if (commandParameters.Length < 3)
            {
                return;
            }

            _id = -1;
            if (!string.IsNullOrWhiteSpace(commandParameters[2]))
            {
                try
                {
                    _id = int.Parse(commandParameters[2]);
                }
                catch
                {
                    _id = -1;
                }
            }
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
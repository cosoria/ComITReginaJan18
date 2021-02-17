using System.ComponentModel;
using DomainLayer.Contracts;

namespace DomainLayer.Commands
{
    public static class CommandFactory
    {
        private static IDatabase _database;

        public static void Init(IDatabase database)
        {
            _database = database;
        }

        public static ICommand Create(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                return new ErrorCommand();
            }

            if (commandName == "exit")
            {
                return new ExitCommand();
            }

            if (commandName == "take")
            {
                return new AttendanceCommand(_database);
            }

            if (commandName == "list")
            {
                return new ListCommand(_database);
            }

            if (commandName == "help")
            {
                return new HelpCommand();
            }

            return new ErrorCommand();
        }
    }
}
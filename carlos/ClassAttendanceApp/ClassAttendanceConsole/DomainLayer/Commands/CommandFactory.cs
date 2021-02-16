namespace DomainLayer.Commands
{
    public static class CommandFactory
    {
        public static ICommand Create(string commandName)
        {
            if (string.IsNullOrWhiteSpace(commandName))
            {
                return ErrorCommand();
            }

            if (commandName == "exit")
            {
                return new ExitCommand();
            }

            if (commandName == "take")
            {
                return new TakeCommand();
            }

            if (commandName == "list")
            {
                return new ListCommand();
            }

            if (commandName == "help")
            {
                return new HelpCommand();
            }

            return ErrorCommand();
        }
    }
}
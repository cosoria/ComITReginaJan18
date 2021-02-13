
namespace DomainLayer
{
    public class CommandResult
    {
        public bool Exit { get; private set; } = false;
        public bool Success => string.IsNullOrWhiteSpace(ErrorText);
        public bool Failed => !Success;
        public string ErrorText { get; private set; } = string.Empty;

        public static CommandResult ExitResult()
        {
            return new CommandResult()
            {
                Exit = true
            };
        }

        public static CommandResult ErrorResult(string errorText)
        {
            return new CommandResult()
            {
                Exit = false, 
                ErrorText = errorText, 
            };
        }

        public static CommandResult OkResult()
        {
            return new CommandResult();
        }
    }
}
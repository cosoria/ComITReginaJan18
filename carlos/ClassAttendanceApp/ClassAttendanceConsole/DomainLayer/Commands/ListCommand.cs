namespace DomainLayer.Commands
{
    public class ListCommand : ICommand 
    {
        public void Init(string commandParameters)
        {
        }

        public string GetHelpText()
        {
            return
@"      Usage: 
            list             : list all students on the course
            list class       : list all classes in the course 
            list class <#>   : list topics for the # class 
            list student <#> : list the student with id #
";
        }

        public CommandResult Execute()
        {
            return CommandResult.ErrorResult("Not implemented just yet");
        }
    }
}
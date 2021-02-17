using DomainLayer.Contracts;

namespace DomainLayer.Commands
{
    public class AttendanceCommand : CommandBase
    {
        private IDatabase _database;

        public AttendanceCommand(IDatabase database)
        {
            _database = database;
        }

        public override CommandResult Execute()
        {
            return CommandResult.OkResult();
        }

        public override string GetHelpText()
        {
            return
@"      Overview:
            Take class attendance for specific student or for the whole class 

        Usage:
            attendance <entity> <id>
                <entity>: is one of 'student','class','course' default value is student
                <id>: is a number according to the entity range from 1 to max records
        
        Examples:
            :> attendance 
            :> attendance class 1
            :> attendance student 13
";
        }
    }
}
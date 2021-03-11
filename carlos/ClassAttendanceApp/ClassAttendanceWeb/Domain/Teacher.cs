namespace ClassAttendance.Domain
{
    public class Teacher
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Experience { get; private set; }

        public Teacher(string firstName, string lastName, string experience)
        {
            FirstName = firstName;
            LastName = lastName;
            Experience = experience;
        }

        public string PrintSummary()
        {
            return $"{FirstName} {LastName}";
        }

        public string PrintDetails()
        {
            return $"{FirstName} {LastName} Experience:{Experience}"; 
        }

        public override string ToString()
        {
            return PrintSummary();
        }
    }
}
namespace ClassAttendance.Domain
{
    public class Teacher : IEntity
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Experience { get; private set; }
        

        public Teacher(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public void SetExperience(string experience)
        {
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
using System.Runtime.CompilerServices;

namespace ClassAttendance.Domain
{
    
    public class Teacher : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Experience { get; private set; }

        protected Teacher() 
        {
        }

        public Teacher(int id, string firstName, string lastName) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Teacher(string firstName, string lastName) : 
            this(0, firstName, lastName)
        {
            
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
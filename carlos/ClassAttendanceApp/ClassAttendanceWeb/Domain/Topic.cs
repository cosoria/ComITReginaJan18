
namespace ClassAttendance.Domain
{
    public class Topic 
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public int Level { get; private set; }

        public Topic(int id, string title, int level)
        {
            Id = id;
            Title = title;
            Level = level;
        }
        
        public string PrintSummary()
        {
            return Title;
        }

        public string PrintDetails()
        {
            return $"{Title} Level:{Level}";
        }

        public override string ToString()
        {
            return PrintSummary();
        }
    }
}
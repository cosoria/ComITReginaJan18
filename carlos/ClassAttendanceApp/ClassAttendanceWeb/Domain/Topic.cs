
namespace ClassAttendanceDomain
{
    public class Topic 
    {
        public string Title { get; private set; }
        public int Level { get; private set; }

        public Topic(string title, int level)
        {
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
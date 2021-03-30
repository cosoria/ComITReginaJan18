
namespace Domain
{
    public class Topic : Entity
    {
        public string Title { get; private set; }
        public int Level { get; private set; }

        protected Topic()
        {
        }

        public Topic(string title, int level) : this(0, title, level)
        {
        }

        public Topic(int id, string title, int level) : base(id)
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
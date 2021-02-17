namespace DomainLayer.Entities
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
    }
}
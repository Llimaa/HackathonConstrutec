using PR.Shared.Entities;

namespace PR.Domain.Entities
{
    public class Comment:Entity
    {
        public Comment()
        {
        }

        public Comment(Report report, Responsible responsible, string title, string description)
        {
            Report = report;
            Responsible = responsible;
            Description = description;
            Title = title;
        }

        public Report Report { get; set; }
        public Responsible Responsible { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}

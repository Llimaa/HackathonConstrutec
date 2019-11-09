using PR.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PR.Domain.Entities
{
    public class Report : Entity
    {
        public Report()
        {
            Comments = new List<Comment>();
        }

        public Report(string title, string image, string description, Responsible responsible, Construction construction)
        {
            Title = title;
            Image = image;
            Description = description;
            Responsible = responsible;
            Construction = construction;
            DateReport = DateTime.Now;
        }

        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Responsible Responsible { get; set; }
        public Construction Construction { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTime DateReport { get; set; }

        public void AddComments(Comment comment)
        {
            Comments.Add(comment);
        }
        public void Update(string title, string image, string description)
        {
            Title = title;
            Image = image;
            Description = description;
        }
    }
}

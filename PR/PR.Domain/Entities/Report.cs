using Flunt.Validations;
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

            AddNotifications(new Contract()
                .IsNullOrEmpty(title, "Title", "O Título é campo obrigatório")
                .IsNullOrEmpty(description, "Description", "A Descrição é campo obrigatório"),

                responsible, construction
                );
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

            AddNotifications(comment);
        }
        public void Update(string title, string image, string description)
        {
            Title = title;
            Image = image;
            Description = description;

            AddNotifications(new Contract()
                .IsNullOrEmpty(title, "Title", "O Título é campo obrigatório")
                .IsNullOrEmpty(description, "Description", "A Descrição é campo obrigatório")
                );
        }

        public Guid ResponsibleId { get; set; }
        public Guid ConstructionId { get; set; }
    }
}

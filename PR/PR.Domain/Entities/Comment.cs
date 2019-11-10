using Flunt.Validations;
using PR.Shared.Entities;
using System;

namespace PR.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment()
        {
        }

        public Comment(Report report, Responsible responsible, string title, string description)
        {
            new Contract()
                  .IsNullOrEmpty(title, "Title", "O Título é campo obrigatório")
                  .IsNullOrEmpty(description, "Description", "A Descrição é campo obrigatório");
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

            AddNotifications(new Contract()
                .IsNullOrEmpty(title, "Title", "O Título é campo obrigatório")
                .IsNullOrEmpty(description, "Description", "A Descrição é campo obrigatório")
                );
        }
        public Guid ReportId { get; set; }
        public Guid ResponsibleId { get; set; }
    }
}

using Flunt.Validations;
using PR.Domain.Enuns;
using PR.Domain.ValueObjects;
using PR.Shared.Entities;
using System;
using System.Collections.Generic;

namespace PR.Domain.Entities
{
    public class Construction : Entity
    {
        public Construction()
        {
            Responsibles = new List<Responsible>();
            Reports = new List<Report>();
        }

        public Construction(string name, Address address, Owner owner, DateTime startDate, DateTime finalDate)
        {
            new Contract()
                .IsNullOrEmpty(name, "Name", "O Nome é campo obrigatório").Join(address);
            Name = name;
            EStatusConstruction = EStatusConstruction.Start;
            Responsibles = new List<Responsible>();
            Address = address;
            Owner = owner;
            StartDate = startDate;
            FinalDate = finalDate;
            
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public EStatusConstruction EStatusConstruction { get; set; }
        public Address Address { get; set; }
        public Owner Owner { get; set; }
        public Responsible Resident { get; set; }
        public Responsible Fiscal1 { get; set; }
        public Responsible Fiscal2 { get; set; }
        public List<Responsible> Responsibles { get; set; }
        public List<Report> Reports { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }

        public void OptionalInformation(string image, Responsible resident, Responsible fiscal1, Responsible fiscal2)
        {
            Image = image;
            Resident = resident;
            Fiscal1 = fiscal1;
            Fiscal2 = fiscal2;

            AddNotifications(resident, fiscal1, fiscal2);
        }
        public void Update(string name, string image, DateTime finalDate)
        {
            Name = name;
            Image = image;
            FinalDate = finalDate;
            Responsibles = new List<Responsible>();
            Reports = new List<Report>();

            AddNotifications(new Contract()
                .IsNullOrEmpty(name, "Name", "O Nome é campo obrigatório")
                );
        }
        public void AddReport(Report report)
        {
            Reports.Add(report);

            AddNotifications(report);
        }
        public void AddResponsible(Responsible responsible)
        {
            Responsibles.Add(responsible);

            AddNotifications(responsible);
        }
        public void UpdateStatus(EStatusConstruction eStatusConstruction)
        {
            EStatusConstruction = eStatusConstruction;
        }
        public Guid OwnerId { get; set; }
        public Guid ResidentId { get; set; }
        public Guid Fiscal1Id { get; set; }
        public Guid Fiscal2Id { get; set; }
    }
}

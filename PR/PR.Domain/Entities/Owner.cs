using Flunt.Validations;
using PR.Domain.ValueObjects;
using PR.Shared.Entities;

namespace PR.Domain.Entities
{
    public class Owner : Entity
    {
        public Owner(string name, string phone, string email, Address address)
        {
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;

            AddNotifications(new Contract()
                .IsNullOrEmpty(name, "Name", "O Nome é campo obrigatório")
                .IsNullOrEmpty(phone, "Phone", "O Telefone é campo obrigatório")
                .IsEmail(email, "Email", "Email invalido"),

                address
                );
        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public void Update(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;

            AddNotifications(new Contract()
                .IsNullOrEmpty(name, "Name", "O Nome é campo obrigatório")
                .IsNullOrEmpty(phone, "Phone", "O Telefone é campo obrigatório")
                .IsEmail(email, "Email", "Email invalido")
                );
        }
    }
}

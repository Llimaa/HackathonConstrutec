using Flunt.Notifications;
using Flunt.Validations;

namespace PR.Domain.ValueObjects
{
    public class Address : Notifiable
    {
        // Endereço
        public Address()
        {
        }
        public Address(string street, string district, string number)
        {
            new Contract()
                .IsNullOrEmpty(street, "Street", "A Rua é campo obrigatório")
                .IsNullOrEmpty(district, "District", "O Bairro é campo obrigatório")
                .IsNullOrEmpty(number, "Number", "O Numero é campo obrigatório");
            Street = street;
            District = district;
            Number = number;


        }
        // Street
        public string Street { get; set; }
        // District
        public string District { get; set; }
        public string Number { get; set; }

        public string CompleteAddress => $"{Street}, {Number} - {District}";

        public void Update(string street, string district, string number)
        {
            Street = street;
            District = district;
            Number = number;

            AddNotifications(new Contract()
                .IsNullOrEmpty(street, "Street", "A Rua é campo obrigatório")
                .IsNullOrEmpty(district, "District", "O Bairro é campo obrigatório")
                .IsNullOrEmpty(number, "Number", "O Numero é campo obrigatório")
                );
        }
    }
}

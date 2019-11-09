namespace PR.Domain.ValueObjects
{
    public class Address
    {
        // Endereço
        public Address()
        {
        }
        public Address(string street, string district, string number)
        {
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
        }
    }
}

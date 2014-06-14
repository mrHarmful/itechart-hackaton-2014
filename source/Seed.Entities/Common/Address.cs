namespace Seed.Entities
{
    public class Address
    {
        public string Country { get; set; }

        public string CountryCode { get; set; }

        public string State { get; set; }

        public string StateCode { get; set; }

        public string City { get; set; }

        public string Neighborhood { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public bool IsBroken { get; set; }

        public bool IsShowAddress { get; set; }
    }
}
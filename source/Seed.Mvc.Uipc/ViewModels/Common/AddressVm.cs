namespace Seed.Web.Uipc.ViewModels
{
    public class AddressVm
    {
        public string Line1
        {
            get
            {
                return Street;
            }
        }

        public string Line2
        {
            get
            {
                return string.Format("{0}, {1} {2}", City, StateCode, Zip);
            }
        }

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

        public bool IsBrokenAddress { get; set; }

        public bool IsShowOnMap
        {
            get { return Latitude.HasValue && Longitude.HasValue; }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2} {3}", Street, City, StateCode, Zip);
        }
    }
}
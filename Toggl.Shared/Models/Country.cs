namespace Toggl.Shared.Models
{
    public sealed class Country
    {
        public long Id { get; }
        public string Name { get; }
        public string CountryCode { get; }

        public Country(
            long id,
            string name,
            string countryCode)
        {
            Id = id;
            Name = name;
            CountryCode = countryCode;
        }
    }
}

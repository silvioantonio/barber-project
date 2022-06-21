namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class ProviderOpeningHoursVO
    {
        public int Id { get; set; }
        public string? OpeningDay { get; set; }

        public DateTime StartHour { get; set; }

        public DateTime EndHour { get; set; }
    }
}

namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class AppointmentCreateVO
    {
        public long ProviderHourId { get; set; }
        public long ProviderId { get; set; }

        public long UserId { get; set; }

        public DateTime Date { get; set; }
    }
}

namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class AppointmentVO
    {
        public long WorkerId { get; set; }

        public long UserId { get; set; }

        public long ProviderHourId { get; set; }

        public DateTime? Date { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}

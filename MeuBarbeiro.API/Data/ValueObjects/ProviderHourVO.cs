using MeuBarbeiro.API.Util.Enums;

namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class ProviderHourVO
    {
        public DateTime? Date { get; set; }

        public DateTime? Hour { get; set; }

        public StatusHour StatusHour { get; set; }
    }
}

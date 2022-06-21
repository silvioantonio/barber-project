using System.ComponentModel.DataAnnotations;
using PH = MeuBarbeiro.API.Models.ProviderHour;
using P = MeuBarbeiro.API.Models.Provider;
using A = MeuBarbeiro.API.Models.Appointment;

namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class WorkerVO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? AvatarId { get; set; }

        [Required]
        public virtual long ProviderId { get; set; }

        public virtual P.Provider? Provider { get; set; }

        public virtual IEnumerable<PH.ProviderHour> ProviderHours { get; set; }

        public virtual IEnumerable<A.Appointment>? Appointments { get; set; }
    }
}

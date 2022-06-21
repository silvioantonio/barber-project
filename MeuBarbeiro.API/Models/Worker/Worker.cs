using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P = MeuBarbeiro.API.Models.Provider;
using PH = MeuBarbeiro.API.Models.ProviderHour;
using A = MeuBarbeiro.API.Models.Appointment;

namespace MeuBarbeiro.API.Models.Worker
{
    public class Worker
    {
        [Key]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("avatar_id")]
        public string? AvatarId { get; set; }

        [Required]
        [Column("provider_id")]
        public virtual long ProviderId { get; set; }

        [Required]
        public virtual IEnumerable<PH.ProviderHour> ProviderHours { get; set; }

        public virtual IEnumerable<A.Appointment>? Appointments { get; set; }
    }
}

using MeuBarbeiro.API.Models.Base;
using MeuBarbeiro.API.Models.Provider;
using MeuBarbeiro.API.Util.Enums;
using W = MeuBarbeiro.API.Models.Worker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class ProviderVO : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string? CpfCnpj { get; set; }

        [Required]
        [StringLength(50)]
        public string BarbershopName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public string? AvatarId { get; set; }

        public IFormFile? Avatar { get; set; }

        public DateTime? CreatedAt { get; set; }

        [Required]
        public AddressVO Address { get; set; }

        [Required]
        public StatusProvider statusProvider { get; set; }

        [Required]
        public string Services { get; set; }

        public virtual IEnumerable<W.Worker>? Workers { get; set; }

        [Required]
        public ProviderOpeningHoursVO ProviderOpeningHours { get; set; }
    }
}

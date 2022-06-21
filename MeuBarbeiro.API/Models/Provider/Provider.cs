using MeuBarbeiro.API.Models.Base;
using W = MeuBarbeiro.API.Models.Worker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeuBarbeiro.API.Util.Enums;

namespace MeuBarbeiro.API.Models.Provider
{
    public class Provider : BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Column("cpf_cnpj")]
        public string? CpfCnpj { get; set; }

        [Required]
        [StringLength(50)]
        [Column("barbershop_name")]
        public string BarbershopName { get; set; }

        [Required]
        [StringLength(50)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        [Column("password")]
        public string password { get; set; }

        [Column("avatar_id")]
        public string AvatarId { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Required]
        [Column("address")]
        public Address Address { get; set; }

        [Required]
        [Column("status")]
        public StatusProvider statusProvider { get; set; }

        [Required]
        [Column("services")]
        public string Services { get; set; }

        public virtual IEnumerable<W.Worker> Workers { get; set; }

        [Required]
        [Column("opening_hours")]
        public ProviderOpeningHours ProviderOpeningHours { get; set; }
    }
}

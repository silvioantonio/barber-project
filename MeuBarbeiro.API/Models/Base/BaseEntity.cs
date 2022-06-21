using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBarbeiro.API.Models.Base
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(150)]
        [Column("name")]
        public string? Name { get; set; }

        [Required]
        [StringLength(12)]
        [Column("phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [Column("birth_date")]
        public DateTime? BirthDate { get; set; }
    }
}

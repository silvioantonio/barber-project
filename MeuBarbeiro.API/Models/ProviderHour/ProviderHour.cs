using MeuBarbeiro.API.Util.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBarbeiro.API.Models.ProviderHour
{
    public class ProviderHour
    {
        [Key]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime? Date { get; set; }

        [Required]
        [Column("hour")]
        public DateTime? Hour { get; set; }

        [Required]
        [Column("status")]
        public StatusHour StatusHour { get; set; }
    }
}

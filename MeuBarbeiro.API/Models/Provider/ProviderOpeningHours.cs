using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBarbeiro.API.Models.Provider
{
    public class ProviderOpeningHours
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("opening_day")]
        public string? OpeningDay { get; set; }

        [Required]
        [Column("start_hour")]
        public DateTime StartHour { get; set; }

        [Required]
        [Column("end_hour")]
        public DateTime EndHour { get; set; }
    }
}

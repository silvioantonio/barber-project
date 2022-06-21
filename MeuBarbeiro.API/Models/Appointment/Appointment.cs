using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using W = MeuBarbeiro.API.Models.Worker;
using U = MeuBarbeiro.API.Models.User;

namespace MeuBarbeiro.API.Models.Appointment
{
    public class Appointment
    {
        [Key]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("date")]
        public DateTime? Date { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdateAt { get; set; }

        [Required]
        [Column("worker_id")]
        public long WorkerId { get; set; }

        [Required]
        [Column("user_id")]
        public long UserId { get; set; }

        [Required]
        [Column("provider_hour_id")]
        public long ProviderHourId { get; set; }
    }
}

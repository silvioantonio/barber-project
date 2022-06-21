using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBarbeiro.API.Models.Provider
{
    public class Address
    {
        [Key]
        [Required]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        [Column("cep")]
        public string Cep { get; set; }

        [Required]
        [StringLength(50)]
        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Required]
        [Column("numero")]
        public int Numero { get; set; }

        [Required]
        [StringLength(50)]
        [Column("rua")]
        public string Rua { get; set; }

        [Required]
        [StringLength(50)]
        [Column("quadra")]
        public string Quadra { get; set; }

        [StringLength(100)]
        [Column("complemento")]
        public string Complemento { get; set; }
    }
}

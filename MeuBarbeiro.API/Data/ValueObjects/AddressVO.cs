using System.ComponentModel.DataAnnotations;

namespace MeuBarbeiro.API.Data.ValueObjects
{
    public class AddressVO
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Cep { get; set; }

        [Required]
        [StringLength(50)]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [StringLength(50)]
        public string Rua { get; set; }

        [Required]
        [StringLength(50)]
        public string Quadra { get; set; }

        [StringLength(100)]
        public string Complemento { get; set; }
    }
}

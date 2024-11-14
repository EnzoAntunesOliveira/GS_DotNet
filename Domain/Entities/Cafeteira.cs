using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs_DotNet.Domain.Entities
{
    public class Cafeteira
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCafeteira { get; set; }

        [Range(0, double.MaxValue)]
        public double CapacidadeAgua { get; set; }

        [Range(0, double.MaxValue)]
        public double Pressao { get; set; }

        [MaxLength(50)]
        public string CapsulasCompativeis { get; set; }

        [MaxLength(50)]
        public string Tecnologia { get; set; }

        public int EletrodomesticoId { get; set; }

        [ForeignKey("EletrodomesticoId")]
        public Eletrodomestico Eletrodomestico { get; set; }
    }
}
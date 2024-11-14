using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs_DotNet.Domain.Entities
{
    public class Geladeira
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGeladeira { get; set; }

        [Range(0, int.MaxValue)]
        public int CapacidadeFreezerLitros { get; set; }

        [Range(0, double.MaxValue)]
        public double ConsumoKwh { get; set; }

        [Range(1, 5)]
        public int QuantidadePortas { get; set; }

        [MaxLength(50)]
        public string TipoDisplay { get; set; }

        public string TemPortaLatas { get; set; }

        public int EletrodomesticoId { get; set; }

        [ForeignKey("EletrodomesticoId")]
        public Eletrodomestico Eletrodomestico { get; set; }
    }
}
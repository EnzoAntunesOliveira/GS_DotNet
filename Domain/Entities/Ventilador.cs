using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs_DotNet.Domain.Entities
{
    public class Ventilador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVentilador { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantidadePas { get; set; }

        [Range(1, 10)]
        public int QuantidadeVelocidades { get; set; }

        [MaxLength(50)]
        public string TipoVentilador { get; set; }

        public string TemInclinacaoRegulavel { get; set; }

        public int EletrodomesticoId { get; set; }

        [ForeignKey("EletrodomesticoId")]
        public Eletrodomestico Eletrodomestico { get; set; }
    }
}
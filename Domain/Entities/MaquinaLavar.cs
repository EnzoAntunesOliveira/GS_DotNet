using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs_DotNet.Domain.Entities
{
    public class MaquinaLavar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaquina { get; set; }

        [Range(0, double.MaxValue)]
        public double CapacidadeKg { get; set; }

        [Range(0, double.MaxValue)]
        public double ConsumoAgua { get; set; }

        [MaxLength(50)]
        public string SistemaLavagem { get; set; }

        [Range(0, int.MaxValue)]
        public int VelocidadeCentrifugacaoRpm { get; set; }

        public string TemAguaQuente { get; set; }

        public int EletrodomesticoId { get; set; }

        [ForeignKey("EletrodomesticoId")]
        public Eletrodomestico Eletrodomestico { get; set; }
    }
}
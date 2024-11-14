using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs_DotNet.Domain.Entities
{
    public class Microondas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMicroondas { get; set; }

        [Range(0, int.MaxValue)]
        public int PotenciaWatts { get; set; }

        [Range(0, 20)]
        public int QuantidadeProgramas { get; set; }

        [Range(0, double.MaxValue)]
        public double DiametroPrato { get; set; }

        [Range(0, int.MaxValue)]
        public int Frequencia { get; set; }

        public string TemDescongelamento { get; set; }

        public int EletrodomesticoId { get; set; }

        [ForeignKey("EletrodomesticoId")]
        public Eletrodomestico Eletrodomestico { get; set; }
    }
}
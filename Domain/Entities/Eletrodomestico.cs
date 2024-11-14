using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs_DotNet.Domain.Entities
{
    public class Eletrodomestico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Voltagem { get; set; }

        [Required]
        [MaxLength(20)]
        public string Marca { get; set; }

        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(10)]
        public string EficienciaEnergetica { get; set; }

        [MaxLength(50)]
        public string Cor { get; set; }

        public float Peso { get; set; }

        [Url]
        public string LinkCompra { get; set; }
        
        public Geladeira Geladeira { get; set; }
        public Microondas Microondas { get; set; }
        public MaquinaLavar Lavadora { get; set; }
        public Cafeteira Cafeteira { get; set; }
        public Ventilador Ventilador { get; set; }
    }
}
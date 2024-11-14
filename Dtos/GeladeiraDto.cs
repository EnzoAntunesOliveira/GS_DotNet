namespace Gs_DotNet.Dtos
{
    public class GeladeiraDto
    {
        public int IdGeladeira { get; set; }
        public int CapacidadeFreezerLitros { get; set; }
        public double ConsumoKwh { get; set; }
        public int QuantidadePortas { get; set; }
        public string TipoDisplay { get; set; }
        public string TemPortaLatas { get; set; }

        public EletrodomesticoDto Eletrodomestico { get; set; }
    }
}
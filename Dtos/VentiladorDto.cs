namespace Gs_DotNet.Dtos
{
    public class VentiladorDto
    {
        public int IdVentilador { get; set; }
        public int QuantidadePas { get; set; }
        public int QuantidadeVelocidades { get; set; }
        public string TipoVentilador { get; set; }
        public string TemInclinacaoRegulavel { get; set; }

        public EletrodomesticoDto Eletrodomestico { get; set; }
    }
}
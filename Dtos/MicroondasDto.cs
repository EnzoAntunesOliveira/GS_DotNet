namespace Gs_DotNet.Dtos
{
    public class MicroondasDto
    {
        public int IdMicroondas { get; set; }
        public int PotenciaWatts { get; set; }
        public int QuantidadeProgramas { get; set; }
        public double DiametroPrato { get; set; }
        public int Frequencia { get; set; }
        public string TemDescongelamento { get; set; }

        public EletrodomesticoDto Eletrodomestico { get; set; }
    }
}
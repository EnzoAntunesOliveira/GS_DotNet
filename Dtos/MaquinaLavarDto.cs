namespace Gs_DotNet.Dtos
{
    public class MaquinaLavarDto
    {
        public int IdMaquina { get; set; }
        public double CapacidadeKg { get; set; }
        public double ConsumoAgua { get; set; }
        public string SistemaLavagem { get; set; }
        public int VelocidadeCentrifugacaoRpm { get; set; }
        public string TemAguaQuente { get; set; }

        public EletrodomesticoDto Eletrodomestico { get; set; }
    }
}
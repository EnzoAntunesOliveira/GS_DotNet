namespace Gs_DotNet.Dtos
{
    public class CafeteiraDto
    {
        public int IdCafeteira { get; set; }
        public double CapacidadeAgua { get; set; }
        public double Pressao { get; set; }
        public string CapsulasCompativeis { get; set; }
        public string Tecnologia { get; set; }

       
        public EletrodomesticoDto Eletrodomestico { get; set; }
    }

    public class EletrodomesticoDto
    {
        public string Voltagem { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string EficienciaEnergetica { get; set; }
        public string Cor { get; set; }
        public float Peso { get; set; }
        public string LinkCompra { get; set; }
    }
}
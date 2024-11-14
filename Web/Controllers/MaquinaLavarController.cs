using Gs_DotNet.Data;
using Gs_DotNet.Domain.Entities;
using Gs_DotNet.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gs_DotNet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaquinaLavarController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaquinaLavarController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<MaquinaLavarDto>> PostMaquinaLavar(MaquinaLavarDto maquinaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eletrodomestico = new Eletrodomestico
            {
                Voltagem = maquinaDto.Eletrodomestico.Voltagem,
                Marca = maquinaDto.Eletrodomestico.Marca,
                Modelo = maquinaDto.Eletrodomestico.Modelo,
                EficienciaEnergetica = maquinaDto.Eletrodomestico.EficienciaEnergetica,
                Cor = maquinaDto.Eletrodomestico.Cor,
                Peso = maquinaDto.Eletrodomestico.Peso,
                LinkCompra = maquinaDto.Eletrodomestico.LinkCompra
            };

            _context.Eletrodomesticos.Add(eletrodomestico);
            await _context.SaveChangesAsync();

            var maquina = new MaquinaLavar
            {
                CapacidadeKg = maquinaDto.CapacidadeKg,
                ConsumoAgua = maquinaDto.ConsumoAgua,
                SistemaLavagem = maquinaDto.SistemaLavagem,
                VelocidadeCentrifugacaoRpm = maquinaDto.VelocidadeCentrifugacaoRpm,
                TemAguaQuente = maquinaDto.TemAguaQuente,
                EletrodomesticoId = eletrodomestico.Id
            };

            _context.Lavadoras.Add(maquina);  
            await _context.SaveChangesAsync();

            maquinaDto.IdMaquina = maquina.IdMaquina;
            maquinaDto.Eletrodomestico = new EletrodomesticoDto
            {
                Voltagem = eletrodomestico.Voltagem,
                Marca = eletrodomestico.Marca,
                Modelo = eletrodomestico.Modelo,
                EficienciaEnergetica = eletrodomestico.EficienciaEnergetica,
                Cor = eletrodomestico.Cor,
                Peso = eletrodomestico.Peso,
                LinkCompra = eletrodomestico.LinkCompra
            };

            return CreatedAtAction(nameof(GetMaquinaLavar), new { id = maquina.IdMaquina }, maquinaDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaquinaLavarDto>> GetMaquinaLavar(int id)
        {
            var maquina = await _context.Lavadoras.FindAsync(id); 

            if (maquina == null)
            {
                return NotFound();
            }

            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(maquina.EletrodomesticoId);

            var maquinaDto = new MaquinaLavarDto
            {
                IdMaquina = maquina.IdMaquina,
                CapacidadeKg = maquina.CapacidadeKg,
                ConsumoAgua = maquina.ConsumoAgua,
                SistemaLavagem = maquina.SistemaLavagem,
                VelocidadeCentrifugacaoRpm = maquina.VelocidadeCentrifugacaoRpm,
                TemAguaQuente = maquina.TemAguaQuente,
                Eletrodomestico = new EletrodomesticoDto
                {
                    Voltagem = eletrodomestico.Voltagem,
                    Marca = eletrodomestico.Marca,
                    Modelo = eletrodomestico.Modelo,
                    EficienciaEnergetica = eletrodomestico.EficienciaEnergetica,
                    Cor = eletrodomestico.Cor,
                    Peso = eletrodomestico.Peso,
                    LinkCompra = eletrodomestico.LinkCompra
                }
            };

            return maquinaDto;
        }
    }
}

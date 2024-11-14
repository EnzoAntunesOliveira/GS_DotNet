using Gs_DotNet.Data;
using Gs_DotNet.Domain.Entities;
using Gs_DotNet.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gs_DotNet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MicroondasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MicroondasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<MicroondasDto>> PostMicroondas(MicroondasDto microondasDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eletrodomestico = new Eletrodomestico
            {
                Voltagem = microondasDto.Eletrodomestico.Voltagem,
                Marca = microondasDto.Eletrodomestico.Marca,
                Modelo = microondasDto.Eletrodomestico.Modelo,
                EficienciaEnergetica = microondasDto.Eletrodomestico.EficienciaEnergetica,
                Cor = microondasDto.Eletrodomestico.Cor,
                Peso = microondasDto.Eletrodomestico.Peso,
                LinkCompra = microondasDto.Eletrodomestico.LinkCompra
            };

            _context.Eletrodomesticos.Add(eletrodomestico);
            await _context.SaveChangesAsync();

            var microondas = new Microondas
            {
                PotenciaWatts = microondasDto.PotenciaWatts,
                QuantidadeProgramas = microondasDto.QuantidadeProgramas,
                DiametroPrato = microondasDto.DiametroPrato,
                Frequencia = microondasDto.Frequencia,
                TemDescongelamento = microondasDto.TemDescongelamento,
                EletrodomesticoId = eletrodomestico.Id
            };

            _context.Microondas.Add(microondas);
            await _context.SaveChangesAsync();

            microondasDto.IdMicroondas = microondas.IdMicroondas;
            microondasDto.Eletrodomestico = new EletrodomesticoDto
            {
                Voltagem = eletrodomestico.Voltagem,
                Marca = eletrodomestico.Marca,
                Modelo = eletrodomestico.Modelo,
                EficienciaEnergetica = eletrodomestico.EficienciaEnergetica,
                Cor = eletrodomestico.Cor,
                Peso = eletrodomestico.Peso,
                LinkCompra = eletrodomestico.LinkCompra
            };

            return CreatedAtAction(nameof(GetMicroondas), new { id = microondas.IdMicroondas }, microondasDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MicroondasDto>> GetMicroondas(int id)
        {
            var microondas = await _context.Microondas.FindAsync(id);

            if (microondas == null)
            {
                return NotFound();
            }

            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(microondas.EletrodomesticoId);

            var microondasDto = new MicroondasDto
            {
                IdMicroondas = microondas.IdMicroondas,
                PotenciaWatts = microondas.PotenciaWatts,
                QuantidadeProgramas = microondas.QuantidadeProgramas,
                DiametroPrato = microondas.DiametroPrato,
                Frequencia = microondas.Frequencia,
                TemDescongelamento = microondas.TemDescongelamento,
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

            return microondasDto;
        }
    }
}

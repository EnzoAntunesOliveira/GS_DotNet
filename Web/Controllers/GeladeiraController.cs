using Gs_DotNet.Data;
using Gs_DotNet.Domain.Entities;
using Gs_DotNet.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gs_DotNet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeladeiraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GeladeiraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<GeladeiraDto>> PostGeladeira(GeladeiraDto geladeiraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eletrodomestico = new Eletrodomestico
            {
                Voltagem = geladeiraDto.Eletrodomestico.Voltagem,
                Marca = geladeiraDto.Eletrodomestico.Marca,
                Modelo = geladeiraDto.Eletrodomestico.Modelo,
                EficienciaEnergetica = geladeiraDto.Eletrodomestico.EficienciaEnergetica,
                Cor = geladeiraDto.Eletrodomestico.Cor,
                Peso = geladeiraDto.Eletrodomestico.Peso,
                LinkCompra = geladeiraDto.Eletrodomestico.LinkCompra
            };

            _context.Eletrodomesticos.Add(eletrodomestico);
            await _context.SaveChangesAsync();

            var geladeira = new Geladeira
            {
                CapacidadeFreezerLitros = geladeiraDto.CapacidadeFreezerLitros,
                ConsumoKwh = geladeiraDto.ConsumoKwh,
                QuantidadePortas = geladeiraDto.QuantidadePortas,
                TipoDisplay = geladeiraDto.TipoDisplay,
                TemPortaLatas = geladeiraDto.TemPortaLatas,
                EletrodomesticoId = eletrodomestico.Id
            };

            _context.Geladeiras.Add(geladeira);
            await _context.SaveChangesAsync();

            geladeiraDto.IdGeladeira = geladeira.IdGeladeira;
            geladeiraDto.Eletrodomestico = new EletrodomesticoDto
            {
                Voltagem = eletrodomestico.Voltagem,
                Marca = eletrodomestico.Marca,
                Modelo = eletrodomestico.Modelo,
                EficienciaEnergetica = eletrodomestico.EficienciaEnergetica,
                Cor = eletrodomestico.Cor,
                Peso = eletrodomestico.Peso,
                LinkCompra = eletrodomestico.LinkCompra
            };

            return CreatedAtAction(nameof(GetGeladeira), new { id = geladeira.IdGeladeira }, geladeiraDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeladeiraDto>> GetGeladeira(int id)
        {
            var geladeira = await _context.Geladeiras.FindAsync(id);

            if (geladeira == null)
            {
                return NotFound();
            }

            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(geladeira.EletrodomesticoId);

            var geladeiraDto = new GeladeiraDto
            {
                IdGeladeira = geladeira.IdGeladeira,
                CapacidadeFreezerLitros = geladeira.CapacidadeFreezerLitros,
                ConsumoKwh = geladeira.ConsumoKwh,
                QuantidadePortas = geladeira.QuantidadePortas,
                TipoDisplay = geladeira.TipoDisplay,
                TemPortaLatas = geladeira.TemPortaLatas,
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

            return geladeiraDto;
        }
    }
}

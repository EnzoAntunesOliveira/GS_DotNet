using Gs_DotNet.Data;
using Gs_DotNet.Domain.Entities;
using Gs_DotNet.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gs_DotNet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentiladorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentiladorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<VentiladorDto>> PostVentilador(VentiladorDto ventiladorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eletrodomestico = new Eletrodomestico
            {
                Voltagem = ventiladorDto.Eletrodomestico.Voltagem,
                Marca = ventiladorDto.Eletrodomestico.Marca,
                Modelo = ventiladorDto.Eletrodomestico.Modelo,
                EficienciaEnergetica = ventiladorDto.Eletrodomestico.EficienciaEnergetica,
                Cor = ventiladorDto.Eletrodomestico.Cor,
                Peso = ventiladorDto.Eletrodomestico.Peso,
                LinkCompra = ventiladorDto.Eletrodomestico.LinkCompra
            };

            _context.Eletrodomesticos.Add(eletrodomestico);
            await _context.SaveChangesAsync();

            var ventilador = new Ventilador
            {
                QuantidadePas = ventiladorDto.QuantidadePas,
                QuantidadeVelocidades = ventiladorDto.QuantidadeVelocidades,
                TipoVentilador = ventiladorDto.TipoVentilador,
                TemInclinacaoRegulavel = ventiladorDto.TemInclinacaoRegulavel,
                EletrodomesticoId = eletrodomestico.Id
            };

            _context.Ventiladores.Add(ventilador);
            await _context.SaveChangesAsync();

            ventiladorDto.IdVentilador = ventilador.IdVentilador;
            ventiladorDto.Eletrodomestico = new EletrodomesticoDto
            {
                Voltagem = eletrodomestico.Voltagem,
                Marca = eletrodomestico.Marca,
                Modelo = eletrodomestico.Modelo,
                EficienciaEnergetica = eletrodomestico.EficienciaEnergetica,
                Cor = eletrodomestico.Cor,
                Peso = eletrodomestico.Peso,
                LinkCompra = eletrodomestico.LinkCompra
            };

            return CreatedAtAction(nameof(GetVentilador), new { id = ventilador.IdVentilador }, ventiladorDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VentiladorDto>> GetVentilador(int id)
        {
            var ventilador = await _context.Ventiladores.FindAsync(id);

            if (ventilador == null)
            {
                return NotFound();
            }

            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(ventilador.EletrodomesticoId);

            var ventiladorDto = new VentiladorDto
            {
                IdVentilador = ventilador.IdVentilador,
                QuantidadePas = ventilador.QuantidadePas,
                QuantidadeVelocidades = ventilador.QuantidadeVelocidades,
                TipoVentilador = ventilador.TipoVentilador,
                TemInclinacaoRegulavel = ventilador.TemInclinacaoRegulavel,
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

            return ventiladorDto;
        }
    }
}

using Gs_DotNet.Data;
using Gs_DotNet.Domain.Entities;
using Gs_DotNet.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gs_DotNet.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafeteiraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CafeteiraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<CafeteiraDto>> PostCafeteira(CafeteiraDto cafeteiraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Crie o Eletrodomestico com base no EletrodomesticoDto dentro do CafeteiraDto
            var eletrodomestico = new Eletrodomestico
            {
                Voltagem = cafeteiraDto.Eletrodomestico.Voltagem,
                Marca = cafeteiraDto.Eletrodomestico.Marca,
                Modelo = cafeteiraDto.Eletrodomestico.Modelo,
                EficienciaEnergetica = cafeteiraDto.Eletrodomestico.EficienciaEnergetica,
                Cor = cafeteiraDto.Eletrodomestico.Cor,
                Peso = cafeteiraDto.Eletrodomestico.Peso,
                LinkCompra = cafeteiraDto.Eletrodomestico.LinkCompra
            };

            // Adicione o Eletrodomestico ao contexto
            _context.Eletrodomesticos.Add(eletrodomestico);
            await _context.SaveChangesAsync();

            // Crie a Cafeteira e associe o ID do Eletrodomestico criado
            var cafeteira = new Cafeteira
            {
                CapacidadeAgua = cafeteiraDto.CapacidadeAgua,
                Pressao = cafeteiraDto.Pressao,
                CapsulasCompativeis = cafeteiraDto.CapsulasCompativeis,
                Tecnologia = cafeteiraDto.Tecnologia,
                EletrodomesticoId = eletrodomestico.Id // Associe a nova Cafeteira ao Eletrodomestico criado
            };

            _context.Cafeteiras.Add(cafeteira);
            await _context.SaveChangesAsync();

            // Atualize o DTO para retornar com o ID gerado
            cafeteiraDto.IdCafeteira = cafeteira.IdCafeteira;
            cafeteiraDto.Eletrodomestico = new EletrodomesticoDto
            {
                Voltagem = eletrodomestico.Voltagem,
                Marca = eletrodomestico.Marca,
                Modelo = eletrodomestico.Modelo,
                EficienciaEnergetica = eletrodomestico.EficienciaEnergetica,
                Cor = eletrodomestico.Cor,
                Peso = eletrodomestico.Peso,
                LinkCompra = eletrodomestico.LinkCompra
            };

            return CreatedAtAction(nameof(GetCafeteira), new { id = cafeteira.IdCafeteira }, cafeteiraDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CafeteiraDto>> GetCafeteira(int id)
        {
            var cafeteira = await _context.Cafeteiras.FindAsync(id);

            if (cafeteira == null)
            {
                return NotFound();
            }

            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(cafeteira.EletrodomesticoId);

            var cafeteiraDto = new CafeteiraDto
            {
                IdCafeteira = cafeteira.IdCafeteira,
                CapacidadeAgua = cafeteira.CapacidadeAgua,
                Pressao = cafeteira.Pressao,
                CapsulasCompativeis = cafeteira.CapsulasCompativeis,
                Tecnologia = cafeteira.Tecnologia,
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

            return cafeteiraDto;
        }
    }
}
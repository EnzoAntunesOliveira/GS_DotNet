using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gs_DotNet.Data;
using Gs_DotNet.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gs_DotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EletrodomesticoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EletrodomesticoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eletrodomestico>>> GetEletrodomesticos()
        {
            return await _context.Eletrodomesticos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Eletrodomestico>> GetEletrodomestico(int id)
        {
            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(id);

            if (eletrodomestico == null)
            {
                return NotFound(new { message = $"Eletrodoméstico com ID {id} não encontrado." });
            }

            return eletrodomestico;
        }

        [HttpPost]
        public async Task<ActionResult<Eletrodomestico>> PostEletrodomestico(Eletrodomestico eletrodomestico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Eletrodomesticos.Add(eletrodomestico);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEletrodomestico), new { id = eletrodomestico.Id }, eletrodomestico);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao salvar o eletrodoméstico.", details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEletrodomestico(int id, Eletrodomestico eletrodomestico)
        {
            if (id != eletrodomestico.Id)
            {
                return BadRequest(new { message = "ID do eletrodoméstico na URL não coincide com o ID no corpo da solicitação." });
            }

            _context.Entry(eletrodomestico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EletrodomesticoExists(id))
                {
                    return NotFound(new { message = $"Eletrodoméstico com ID {id} não encontrado." });
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEletrodomestico(int id)
        {
            var eletrodomestico = await _context.Eletrodomesticos.FindAsync(id);
            if (eletrodomestico == null)
            {
                return NotFound(new { message = $"Eletrodoméstico com ID {id} não encontrado." });
            }

            _context.Eletrodomesticos.Remove(eletrodomestico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EletrodomesticoExists(int id)
        {
            return _context.Eletrodomesticos.Any(e => e.Id == id);
        }
    }
}

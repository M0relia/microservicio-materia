using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroservicioMateria.Data;
using MicroservicioMateria.Models;

namespace MicroservicioMateria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MateriaController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/Materia
        [HttpGet]
        public async Task<IActionResult> GetMaterias()
        {
            var materias = await _context.Materias.ToListAsync();
            return Ok(materias);
        }

                // GET /api/Materia/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
                return NotFound();

            return Ok(materia);
        }

        // POST /api/Materia
        [HttpPost]
        public async Task<IActionResult> CrearMateria(Materia materia)
        {
            _context.Materias.Add(materia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMateria), new { id = materia.Id }, materia);
        }

        // PUT /api/Materia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarMateria(int id, Materia materia)
        {
            if (id != materia.Id)
                return BadRequest("El ID de la URL no coincide con el ID del cuerpo.");

            _context.Entry(materia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(materia);
        }

        // DELETE /api/Materia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
                return NotFound();

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsManagement_Chayma.Models;

namespace EventsManagement_Chayma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly EventsClientDbContext _context;

        public OrganizersController(EventsClientDbContext context)
        {
            _context = context;
        }

        // GET: api/Organizers
        [HttpGet("get-all-organizers")]
        public async Task<ActionResult<IEnumerable<Organizer>>> GetOrganizers()
        {
          if (_context.Organizers == null)
          {
              return NotFound();
          }
            return await _context.Organizers.ToListAsync();
        }

        // GET: api/Organizers/5
        [HttpGet("get-organizer-by-id/{id}")]
        public async Task<ActionResult<Organizer>> GetOrganizer(int id)
        {
          if (_context.Organizers == null)
          {
              return NotFound();
          }
            var organizer = await _context.Organizers.FindAsync(id);

            if (organizer == null)
            {
                return NotFound();
            }

            return organizer;
        }

        // PUT: api/Organizers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit-organizer/{id}")]
        public async Task<IActionResult> PutOrganizer(int id, Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Organizers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create-organizer")]
        public async Task<ActionResult<Organizer>> PostOrganizer(Organizer organizer)
        {
          if (_context.Organizers == null)
          {
              return Problem("Entity set 'EventsDbContext.Organizers'  is null.");
          }
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizer", new { id = organizer.Id }, organizer);
        }

        // DELETE: api/Organizers/5
        [HttpDelete("delete-organizer/{id}")]
        public async Task<IActionResult> DeleteOrganizer(int id)
        {
            if (_context.Organizers == null)
            {
                return NotFound();
            }
            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }

            _context.Organizers.Remove(organizer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizerExists(int id)
        {
            return (_context.Organizers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

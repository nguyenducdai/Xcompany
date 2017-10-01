using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Data;

namespace Portal.Areas.CPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/PagesAPI")]
    public class PagesAPIController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public PagesAPIController(PortalDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PagesAPI
        [HttpGet]
        public IEnumerable<Pages> GetPages()
        {
            return _context.Pages;
        }

        // GET: api/PagesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pages = await _context.Pages.SingleOrDefaultAsync(m => m.Id == id);

            if (pages == null)
            {
                return NotFound();
            }

            return Ok(pages);
        }

        // PUT: api/PagesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPages([FromRoute] int id, [FromBody] Pages pages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pages.Id)
            {
                return BadRequest();
            }

            _context.Entry(pages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagesExists(id))
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

        // POST: api/PagesAPI
        [HttpPost]
        public async Task<IActionResult> PostPages([FromBody] Pages pages)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pages.Add(pages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPages", new { id = pages.Id }, pages);
        }

        // DELETE: api/PagesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pages = await _context.Pages.SingleOrDefaultAsync(m => m.Id == id);
            if (pages == null)
            {
                return NotFound();
            }

            _context.Pages.Remove(pages);
            await _context.SaveChangesAsync();

            return Ok(pages);
        }

        private bool PagesExists(int id)
        {
            return _context.Pages.Any(e => e.Id == id);
        }
    }
}
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
    [Route("api/MenusAPI")]
    public class MenusAPIController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public MenusAPIController(PortalDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MenusAPI
        [HttpGet]
        public IEnumerable<Menus> GetMenus()
        {
            return _context.Menus;
        }

        // GET: api/MenusAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menus = await _context.Menus.SingleOrDefaultAsync(m => m.Id == id);

            if (menus == null)
            {
                return NotFound();
            }

            return Ok(menus);
        }

        // PUT: api/MenusAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenus([FromRoute] int id, [FromBody] Menus menus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menus.Id)
            {
                return BadRequest();
            }

            _context.Entry(menus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenusExists(id))
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

        // POST: api/MenusAPI
        [HttpPost]
        public async Task<IActionResult> PostMenus([FromBody] Menus menus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Menus.Add(menus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenus", new { id = menus.Id }, menus);
        }

        // DELETE: api/MenusAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenus([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menus = await _context.Menus.SingleOrDefaultAsync(m => m.Id == id);
            if (menus == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menus);
            await _context.SaveChangesAsync();

            return Ok(menus);
        }

        private bool MenusExists(int id)
        {
            return _context.Menus.Any(e => e.Id == id);
        }
    }
}
﻿using System;
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
    [Route("api/StaffAwesomeAPI")]
    public class StaffAwesomeAPIController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public StaffAwesomeAPIController(PortalDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/StaffAwesomeAPI
        [HttpGet]
        public IEnumerable<StaffAwesome> GetStaffAwesome()
        {
            return _context.StaffAwesome;
        }

        // GET: api/StaffAwesomeAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffAwesome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffAwesome = await _context.StaffAwesome.SingleOrDefaultAsync(m => m.Id == id);

            if (staffAwesome == null)
            {
                return NotFound();
            }

            return Ok(staffAwesome);
        }

        // PUT: api/StaffAwesomeAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffAwesome([FromRoute] int id, [FromBody] StaffAwesome staffAwesome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffAwesome.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffAwesome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffAwesomeExists(id))
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

        // POST: api/StaffAwesomeAPI
        [HttpPost]
        public async Task<IActionResult> PostStaffAwesome([FromBody] StaffAwesome staffAwesome)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StaffAwesome.Add(staffAwesome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffAwesome", new { id = staffAwesome.Id }, staffAwesome);
        }

        // DELETE: api/StaffAwesomeAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAwesome([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var staffAwesome = await _context.StaffAwesome.SingleOrDefaultAsync(m => m.Id == id);
            if (staffAwesome == null)
            {
                return NotFound();
            }

            _context.StaffAwesome.Remove(staffAwesome);
            await _context.SaveChangesAsync();

            return Ok(staffAwesome);
        }

        private bool StaffAwesomeExists(int id)
        {
            return _context.StaffAwesome.Any(e => e.Id == id);
        }
    }
}
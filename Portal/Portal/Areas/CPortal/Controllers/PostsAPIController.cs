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
    [Route("api/PostsAPI")]
    public class PostsAPIController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public PostsAPIController(PortalDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/PostsAPI
        [HttpGet]
        public IEnumerable<Posts> GetPosts()
        {
            return _context.Posts;
        }

        // GET: api/PostsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posts = await _context.Posts.SingleOrDefaultAsync(m => m.Id == id);

            if (posts == null)
            {
                return NotFound();
            }

            return Ok(posts);
        }

        // PUT: api/PostsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPosts([FromRoute] int id, [FromBody] Posts posts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != posts.Id)
            {
                return BadRequest();
            }

            _context.Entry(posts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostsExists(id))
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

        // POST: api/PostsAPI
        [HttpPost]
        public async Task<IActionResult> PostPosts([FromBody] Posts posts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Posts.Add(posts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPosts", new { id = posts.Id }, posts);
        }

        // DELETE: api/PostsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posts = await _context.Posts.SingleOrDefaultAsync(m => m.Id == id);
            if (posts == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(posts);
            await _context.SaveChangesAsync();

            return Ok(posts);
        }

        private bool PostsExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
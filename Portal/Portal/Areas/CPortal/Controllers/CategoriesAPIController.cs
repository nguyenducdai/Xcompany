using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portal.Data;
using Portal.Areas.CPortal.Models;
using System.IO;
using AutoMapper;

namespace Portal.Areas.CPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/CategoriesAPI")]
    public class CategoriesAPIController : Controller
    {
        private readonly PortalDatabaseContext _context;

        public CategoriesAPIController(PortalDatabaseContext context)
        {
            _context = context;
        }

        // copyand move File

        [HttpPost]
        [Route("Upload")]
        public IActionResult Upload()
        {

          
            return Ok();
        }

        /// <summary>
        ///     RECURSIVE AND SORT CATEGORY 
        /// </summary>
        int? parentID = 0; string str = string.Empty; string parentName = string.Empty; List<CategoryViewModel> listCategorySort = new List<CategoryViewModel>();
        public List<CategoryViewModel> GetListCategory(int? parentID, List<CategoryViewModel> categoryList)
        {
            var obj = from cat in _context.Categories
                      where cat.ParentId == parentID
                      select cat;

            foreach (var item in obj)
            {
                if (item.ParentId == null)
                {
                    parentName = "N/A";
                    str = string.Empty;
                }
                else if (item.ParentId == parentID)
                {

                    parentName = _context.Categories.FirstOrDefault(x => x.Id == item.ParentId).Name;
                    str += "--";
                }

                var categoryVM = Mapper.Map<Categories, CategoryViewModel>(item);
                categoryVM.SubText = str;
                categoryVM.ParentName = parentName;

                listCategorySort.Add(categoryVM);

                var hasSubCat = (from cat in _context.Categories
                                 where cat.ParentId == item.Id
                                 select cat).Count();
                if (hasSubCat > 0)
                {
                    GetListCategory(item.Id, categoryList);
                }
            }
            return listCategorySort;
        }// end recurcive


        // GET: api/CategoriesAPI
        [HttpGet]
        public IEnumerable<Categories> GetCategories()
        {
            return _context.Categories;
        }

        // CALL RECURSIVE
        [HttpGet]
        [Route("GetListRecursiveCategories")]
        public IActionResult GetListRecursiveCategories()
        {
            List<Categories> cat = _context.Categories.ToList();
            var listCategoryVM = GetListCategory(null, Mapper.Map<List<Categories>, List<CategoryViewModel>>(cat));
            return Ok(listCategoryVM);
        }

        // GET: api/CategoriesAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        // PUT: api/CategoriesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories([FromRoute] int id, [FromBody] Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categories.Id)
            {
                return BadRequest();
            }

            _context.Entry(categories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
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

        // POST: api/CategoriesAPI
        [HttpPost]
        public async Task<IActionResult> PostCategories([FromBody] Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategories", new { id = categories.Id }, categories);
        }

        // DELETE: api/CategoriesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categories = await _context.Categories.SingleOrDefaultAsync(m => m.Id == id);
            if (categories == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();

            return Ok(categories);
        }

        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
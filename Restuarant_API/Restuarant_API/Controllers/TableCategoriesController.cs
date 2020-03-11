using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_API.Models;

namespace Restaurant_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableCategoriesController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public TableCategoriesController(RestaurantDbContext context)
        {
            _context = context;
        }

        // GET: api/TableCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableCategory>>> GetTableCategories()
        {
            return await _context.TableCategories.ToListAsync();
        }

        // GET: api/TableCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableCategory>> GetTableCategory(int id)
        {
            var tableCategory = await _context.TableCategories.FindAsync(id);

            if (tableCategory == null)
            {
                return NotFound();
            }

            return tableCategory;
        }

        // PUT: api/TableCategories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableCategory(int id, TableCategory tableCategory)
        {
            if (id != tableCategory.TableCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(tableCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableCategoryExists(id))
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

        // POST: api/TableCategories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TableCategory>> PostTableCategory(TableCategory tableCategory)
        {
            _context.TableCategories.Add(tableCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableCategory", new { id = tableCategory.TableCategoryId }, tableCategory);
        }

        // DELETE: api/TableCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableCategory>> DeleteTableCategory(int id)
        {
            var tableCategory = await _context.TableCategories.FindAsync(id);
            if (tableCategory == null)
            {
                return NotFound();
            }

            _context.TableCategories.Remove(tableCategory);
            await _context.SaveChangesAsync();

            return tableCategory;
        }

        private bool TableCategoryExists(int id)
        {
            return _context.TableCategories.Any(e => e.TableCategoryId == id);
        }
    }
}

using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreService.Data;

namespace StoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoreContext _context;

        public StoresController(StoreContext context) => _context = context;

        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        // GET: api/Stores/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Store>> GetStore(Guid id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null) return NotFound();

            return store;
        }

        // POST: api/Stores
        [HttpPost]
        public async Task<ActionResult<Store>> CreateStore(Store store)
        {
            store.Id = Guid.NewGuid();

            _context.Stores.Add(store);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStore), new { id = store.Id }, store);
        }

        // PUT: api/Stores/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(Guid id, Store store)
        {
            if (id != store.Id) return BadRequest();

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.Stores.Any(e => e.Id == id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Stores/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(Guid id)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null) return NotFound();

            _context.Stores.Remove(store);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Stores/{id}/AddBook/{bookId}
        [HttpPut("{id}/AddBook/{bookId}")]
        public async Task<IActionResult> AddBookToStore(Guid id, Guid bookId)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null) return NotFound();

            if (!store.BookIds.Contains(bookId))
            {
                store.BookIds.Add(bookId);

                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // PUT: api/Stores/{id}/RemoveBook/{bookId}
        [HttpPut("{id}/RemoveBook/{bookId}")]
        public async Task<IActionResult> RemoveBookFromStore(Guid id, Guid bookId)
        {
            var store = await _context.Stores.FindAsync(id);

            if (store == null) return NotFound();

            if (store.BookIds.Contains(bookId))
            {
                store.BookIds.Remove(bookId);

                await _context.SaveChangesAsync();
            }

            return NoContent();
        }
    }
}

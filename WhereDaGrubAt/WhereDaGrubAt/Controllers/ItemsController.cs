/*
 * David Lockwood
 * ItemsController is the Controller for all Inventory Views as well as all Item CRUD operations
 * 
 * inputs: _context: DbContext, Used to query the database
 *         itemCategory: string, Used in query to filter by Category
 *         searchString: string, Used in query to filter by most relevant Item Name
 *         id: int, Used to perform CRUD operations
 *         item: Item, Contains all fields that an item consists of and used to perform CRUD operations
 *         
 * output: itemCategoryVM: ViewResult, ViewModel containing filtered Inventory items
 *         item: ViewResult, model containing the specified Item's fields
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhereDaGrubAt.Data;
using WhereDaGrubAt.Models;

namespace WhereDaGrubAt.Controllers
{
    public class ItemsController : Controller
    {
        private readonly WhereDaGrubAtContext _context;

        public ItemsController(WhereDaGrubAtContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string itemCategory, string searchString)
        {
            IQueryable<string> categoryQuery = from m in _context.Item
                                               orderby m.Category
                                               select m.Category;

            var items = from m in _context.Item
                        select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(itemCategory))
            {
                items = items.Where(x => x.Category == itemCategory);
            }

            var itemCategoryVM = new ItemCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Items = await items.ToListAsync()
            };

            return View(itemCategoryVM);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Description,Quantity,ExpirationDate,NotUserDefined")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,Description,Quantity,ExpirationDate,NotUserDefined")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}

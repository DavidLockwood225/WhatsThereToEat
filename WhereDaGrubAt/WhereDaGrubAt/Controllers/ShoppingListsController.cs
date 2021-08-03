using System;
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
    public class ShoppingListsController : Controller
    {
        private readonly WhereDaGrubAtContext _context;

        public ShoppingListsController(WhereDaGrubAtContext context)
        {
            _context = context;
        }

        // GET: ShoppingLists
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoppingList.ToListAsync());
        }

        // GET: ShoppingLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _context.ShoppingList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            return View(shoppingList);
        }

        // GET: ShoppingLists/Create
        public IActionResult Create()
        {
            var itemList = new ShoppingListViewModel();
            itemList.ListItems = GetItems();

            return View(itemList);
        }

        // POST: ShoppingLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,ItemDescription,ItemQuantity,Checked")] ShoppingList shoppingList)
        {

            if (ModelState.IsValid)
            {
                _context.Add(shoppingList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingList);
        }

        // GET: ShoppingLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _context.ShoppingList.FindAsync(id);
            if (shoppingList == null)
            {
                return NotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,ItemDescription,ItemQuantity,Checked")] ShoppingList shoppingList)
        {
            if (id != shoppingList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingListExists(shoppingList.Id))
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
            return View(shoppingList);
        }

        // GET: ShoppingLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingList = await _context.ShoppingList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingList == null)
            {
                return NotFound();
            }

            return View(shoppingList);
        }

        // POST: ShoppingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingList = await _context.ShoppingList.FindAsync(id);
            _context.ShoppingList.Remove(shoppingList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IEnumerable<SelectListItem> GetItems()
        {
            List<SelectListItem> items = _context.Item
                                        .OrderBy(n => n.Name)
                                            .Select(n =>
                                            new SelectListItem
                                            {
                                                Value = n.Name,
                                                Text = n.Name
                                            }).ToList();

            return new SelectList(items, "Value", "Text");
        }

        private bool ShoppingListExists(int id)
        {
            return _context.ShoppingList.Any(e => e.Id == id);
        }
    }
}

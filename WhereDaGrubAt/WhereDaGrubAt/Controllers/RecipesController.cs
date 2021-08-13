﻿/*
 * David Lockwood
 * RecipesController is the Controller for all Recipe Views as well as all Recipe CRUD operations
 * 
 * inputs: _context: DbContext, Used to query the database
 *         recipeCategory: string, Used in query to filter by Category
 *         searchString: string, Used in query to filter by most relevant Recipe's Title
 *         id: int, Used to perform CRUD operations
 *         recipe: Recipe, Contains all fields that an recipe consists of and used to perform CRUD operations
 *         
 * output: recipeCategoryVM: ViewResult, ViewModel containing filtered Recipes
 *         recipe: ViewResult, model containing the specified Recipe's fields
 */

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
    public class RecipesController : Controller
    {
        private readonly WhereDaGrubAtContext _context;

        public RecipesController(WhereDaGrubAtContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index(string recipeCategory, string searchString)
        {
            IQueryable<string> categoryQuery = from m in _context.Recipe
                                            orderby m.Category
                                            select m.Category;


            var recipes = from m in _context.Recipe
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(s => s.Title.Contains(searchString) | s.Category.Contains(searchString) | s.Ingredients.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(recipeCategory))
            {
                recipes = recipes.Where(x => x.Category == recipeCategory);
            }

            var recipeCategoryVM = new RecipeCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Recipes = await recipes.ToListAsync()
            };
            return View(recipeCategoryVM);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            var recipeVM = new RecipeViewModel
            {
                Id = recipe.Id,
                Title = recipe.Title,
                Category = recipe.Category,
                ServingSize = recipe.ServingSize,
                RecipeIngredients = recipe.Ingredients.Split(new char[] { ',' }).ToList(),
                RecipeDirections = recipe.Directions.Split(new char[] { ',' }).ToList()
            };

            return View(recipeVM);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Category,ServingSize,Ingredients,Directions,NotUserDefined")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Category,ServingSize,Ingredients,Directions,NotUserDefined")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }
    }
}

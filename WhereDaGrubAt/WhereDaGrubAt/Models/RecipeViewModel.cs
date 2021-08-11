/*
 * David Lockwood
 * ViewModel used for displaying Recipe content in the Recipes/Details view
 */

using System.Collections.Generic;

namespace WhereDaGrubAt.Models
{
    public class RecipeViewModel : Recipe
    {
        public List<string> RecipeIngredients { get; set; }
        public List<string> RecipeDirections { get; set; }
    }
}

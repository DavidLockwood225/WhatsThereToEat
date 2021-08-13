/*
 * David Lockwood
 * ViewModel used for displaying Recipe content in the Recipes/Details view
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhereDaGrubAt.Models
{
    public class RecipeViewModel : Recipe
    {
        [Display(Name = "Ingredients")]
        public List<string> RecipeIngredients { get; set; }
        [Display(Name = "Directions")]
        public List<string> RecipeDirections { get; set; }
    }
}

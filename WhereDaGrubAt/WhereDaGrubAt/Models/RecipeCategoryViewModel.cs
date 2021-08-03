using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhereDaGrubAt.Models
{
    public class RecipeCategoryViewModel
    {
        public List<Recipe> Recipes { get; set; }
        public SelectList Categories { get; set; }
        public string RecipeCategory { get; set; }
        public string SearchString { get; set; }
    }
}

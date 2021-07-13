using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereDaGrubAt.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string ServingSize { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Directions { get; set; }
    }
}

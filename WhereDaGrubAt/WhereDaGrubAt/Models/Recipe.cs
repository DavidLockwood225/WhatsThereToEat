/*
 * David Lockwood
 * Model for the Recipe class fields
 */

using System.ComponentModel.DataAnnotations;

namespace WhereDaGrubAt.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Category { get; set; }
        [Display(Name = "Servings")]
        public string ServingSize { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public bool NotUserDefined { get; set; }
    }
}

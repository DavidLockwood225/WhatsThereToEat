/*
 * David Lockwood
 * Model for the Recipe class fields
 */

namespace WhereDaGrubAt.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string ServingSize { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public bool NotUserDefined { get; set; }
    }
}

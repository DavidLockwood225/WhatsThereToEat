/*
 * David Lockwood
 * Model for the Shopping List class fields
 */

using System.ComponentModel.DataAnnotations;

namespace WhereDaGrubAt.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string ItemName { get; set; }
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }
        [Display(Name = "Quantity")]
        public int ItemQuantity { get; set; }
        public bool Checked { get; set; }
        [Display(Name = "Shopping List Name")]
        public string ListTitle { get; set; }
    }
}

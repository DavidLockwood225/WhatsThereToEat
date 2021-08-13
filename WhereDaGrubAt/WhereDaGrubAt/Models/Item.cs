/*
 * David Lockwood
 * Model for the Item class fields
 */

using System;
using System.ComponentModel.DataAnnotations;

namespace WhereDaGrubAt.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }
        public bool NotUserDefined { get; set; }
    }    
}

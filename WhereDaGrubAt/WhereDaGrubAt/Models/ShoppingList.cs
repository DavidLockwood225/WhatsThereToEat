using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhereDaGrubAt.Models
{
    public class ShoppingList
    {
        [Key] 
        [Column(Order = 1)]
        public int Id { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "Name")]
        public string ItemName { get; set; }
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }
        [Display(Name = "Quantity")]
        public int ItemQuantity { get; set; }
        public bool Checked { get; set; }
    }
}

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
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemQuantity { get; set; }
        public bool Checked { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhereDaGrubAt.Models
{
    public class ShoppingListViewModel : ShoppingList
    {
        public List<ShoppingList> List { get; set; }
        public SelectList ListNames { get; set; }
        public string ListName { get; set; }
        public string SearchString { get; set; }
        public int SelectedItemId { get; set; }
        public IEnumerable<SelectListItem> ListItems { get; set; }
    }
}

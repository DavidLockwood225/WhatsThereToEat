/*
 * David Lockwood
 * ViewModel for filtering shopping list items by the shopping list's name, as well as populating item Name dropdown menu in ShoppingLists/Create view
 */

using System.Collections.Generic;
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

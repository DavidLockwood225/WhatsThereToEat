/*
 * David Lockwood
 * ViewModel for UI filtering by Item Category and Name
 */

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhereDaGrubAt.Models
{
    public class ItemCategoryViewModel
    {
        public List<Item> Items { get; set; }
        public SelectList Categories { get; set; }
        public string ItemCategory { get; set; }
        public string SearchString { get; set; }
    }
}

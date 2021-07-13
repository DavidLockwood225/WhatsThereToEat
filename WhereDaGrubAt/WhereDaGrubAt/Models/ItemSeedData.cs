using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhereDaGrubAt.Data;

namespace WhereDaGrubAt.Models
{
    public static class ItemSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WhereDaGrubAtContext(serviceProvider.GetRequiredService<DbContextOptions<WhereDaGrubAtContext>>()))
            {
                if (context.Item.Any())
                {
                    return;
                }
                context.Item.AddRange(
                    new Item
                    {
                        Name = "Russet Potato",
                        Category = "Vegetable",
                        Description = "A large brown potato",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Butter",
                        Category = "Dairy",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Half-and-Half",
                        Category = "Dairy",
                        Description = "Half whole milk half light cream",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Salt",
                        Category = "Seasoning",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Black Pepper",
                        Category = "Seasoning",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Macaroni",
                        Category = "Pasta",
                        Description = "Elbow shaped noodles",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Egg",
                        Category = "Poultry",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Flour",
                        Category = "Grain",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Whole Milk",
                        Category = "Dairy",
                        Description = "Contains 3.5% percent milk fat",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Cheddar Cheese",
                        Category = "Dairy",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Chicken Breast",
                        Category = "Poultry",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Garlic Powder",
                        Category = "Seafood",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Olive Oil",
                        Category = "Misc",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Shrimp",
                        Category = "Seafood",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Garlic Clove",
                        Category = "Vegetable",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Lemon",
                        Category = "Fruit",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    },
                    new Item
                    {
                        Name = "Broccoli",
                        Category = "Vegetable",
                        Description = "",
                        ExpirationDate = DateTime.Today
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

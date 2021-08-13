/*
 * David Lockwood
 * Model containing seed data for Item table
 */

using System;
using System.Linq;
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
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Butter",
                        Category = "Dairy",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Half-and-Half",
                        Category = "Dairy",
                        Description = "Half whole milk half light cream",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Salt",
                        Category = "Seasoning",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Black Pepper",
                        Category = "Seasoning",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Macaroni",
                        Category = "Pasta",
                        Description = "Elbow shaped noodles",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Egg",
                        Category = "Poultry",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Flour",
                        Category = "Grain",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Whole Milk",
                        Category = "Dairy",
                        Description = "Contains 3.5% percent milk fat",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Cheddar Cheese",
                        Category = "Dairy",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Chicken Breast",
                        Category = "Poultry",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Garlic Powder",
                        Category = "Seasoning",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Olive Oil",
                        Category = "Misc",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Shrimp",
                        Category = "Seafood",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Garlic Clove",
                        Category = "Vegetable",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Lemon",
                        Category = "Fruit",
                        Description = "",
                        NotUserDefined = true
                    },
                    new Item
                    {
                        Name = "Broccoli",
                        Category = "Vegetable",
                        Description = "",
                        NotUserDefined = true
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

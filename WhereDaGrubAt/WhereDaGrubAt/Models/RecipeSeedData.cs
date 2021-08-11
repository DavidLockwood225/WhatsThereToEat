/*
 * David Lockwood
 * Model containing seed data for Recipe table
 */

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WhereDaGrubAt.Data;

namespace WhereDaGrubAt.Models
{
    public static class RecipeSeedData
    {
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new WhereDaGrubAtContext(serviceProvider.GetRequiredService<DbContextOptions<WhereDaGrubAtContext>>()))
                {
                    if (context.Recipe.Any())
                    {
                        return;
                    }
                    context.Recipe.AddRange(
                        new Recipe
                        {
                            Title = "Mashed Potatoes",
                            Category = "Vegetable",
                            ServingSize = "10",
                            Ingredients = "5 Russet Potatoes, 3/4 cup Butter, 3/4 cup Half-and-Half, 1 teaspoon Salt, 1 teaspoon Black Pepper",
                            Directions = "Boil potatoes for 30 to 35 minutes, Drain water and mash potatoes over low heat," +
                            "Add rest of the ingredients to potatoes, Mash potatoes until creamy",
                            NotUserDefined = true
                        },
                        new Recipe
                        {
                            Title = "Mac N Cheese",
                            Category = "Pasta",
                            ServingSize = "6",
                            Ingredients = "4 cups Macaroni, 1 whole Egg, 1/4 cup Butter, 1/4 cup Flour, 2 1/2 cups Whole Milk, 1 pound Cheddar Cheese grated, 1 teaspoon Salt, 1 teaspoon Black Pepper",
                            Directions = "Boil macaroni and drain, Beat the egg, Melt butter in a pot and sprinkle flour in, Whisk together over medium-low heat for 5 minutes" +
                            "Pour in milk and whisk until smooth for 5 minutes, Pour sauce into the beaten egg while whisking, Add cheese and stir until it is melted, Add salt and pepper," +
                            "Pour macaroni in cheese sauce and stir",
                            NotUserDefined = true
                        },
                        new Recipe
                        {
                            Title = "Grilled Chicken",
                            Category = "Poultry",
                            ServingSize = "4",
                            Ingredients = "2 pounds Chicken Breast, 1 teaspoon Salt, 1/2 teaspoon Black Pepper, 1/2 teaspoon Garlic Powder, Olive Oil as needed",
                            Directions = "Preheat stove to medium high heat, Lightly oil pan, Stir together seasoning in a small bowl, Place chicken breasts in large bowl and sprinkle seasoning mixture over" +
                            "chicken and toss to coat, Cook chicken in pan for 4 to 5 minutes per side",
                            NotUserDefined = true
                        },
                        new Recipe
                        {
                            Title = "Grilled Shrimp",
                            Category = "Seafood",
                            ServingSize = "6 to 8",
                            Ingredients = "2 1/2 pounds Shrimp, 3 Garlic Cloves chopped and peeled, 1 teaspoon Salt, 1/4 teaspoon Black Pepper, 1 Lemon, Olive Oil as needed",
                            Directions = "Peel shrimp and remove tails or vein if needed, Preheat stove to medium heat, Combine lemon juice and seasoning in a large bowl, Add garlic to the mixture, " +
                            "Add cleaned shrimp and toss to coat, Cover and refrigerate for 15 minutes, Remove shrimp from the marinade and place in pan, Cook shrimp in pan for 2 to 3 minutes per side",
                            NotUserDefined = true
                        },
                        new Recipe
                        {
                            Title = "Steamed Broccoli",
                            Category = "Vegetable",
                            ServingSize = "4",
                            Ingredients = "4 cups Broccoli, 1/2 teaspoon Salt, 1/2 teaspoon Black Pepper , 1/2 teaspoon Garlic Powder, 1/2 teaspoon Olive Oil",
                            Directions = "Add 1 cup water to saucepan, Add broccoli to saucepan, Cover and cook for 5 to 6 minutes while stirring occasionally, Mix together olive oil and seasoning" +
                            "Add seasoning mixture to cooked broccoli and stir well",
                            NotUserDefined = true
                        }
                        );
                    context.SaveChanges();
                }
            }        
    }
}

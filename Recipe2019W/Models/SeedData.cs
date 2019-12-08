using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Recipe2019W.DataType;

namespace Recipe2019W.Models
{
    public class SeedData
    {
        // Make Sure the Database is Populated
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            // Instance of ApplicationDBContext
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();

            // Call Migration Scripts, Migration scripts will run automatically
            context.Database.Migrate();

            // Check if the Recipes are already there
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        Name = "Chocolate Peppermint Cheesecake",
                        Description = "Instead of heading to the Cheesecake Factory make your own decadent peppermint cheesecake." +
                                      "With a Oreo crust and ganache topping this is our favorite cheesecake to make for Christmas. " +
                                      "It's peppermint bark in cheesecake form and we can't get enough! ",
                        NumOfServings = 8,
                        PrepTime = 30,
                        TotalTime = 480,
                        Creator = "LINDSAY FUNSTON",
                        DateCreated = new DateTime(2019, 12, 6),
                        Type = RecipeCategory.DESSERT.ToString()
                    },
                    new Recipe
                    {
                        Name = "Popcorn Shrimp",
                        Description = "Popcorn shrimp should be two things: Easy to make and easy to eat." +
                                      "This shrimp is certainly both! With a homemade spicy tartar sauce, " +
                                      "they are completely addictive and you'll want to just keep poppin' them in your mouth! ",

                        NumOfServings = 4,
                        PrepTime = 20,
                        TotalTime = 40,
                        Creator = "MAKINZE GORE",
                        DateCreated = new DateTime(2019, 12, 6),
                        Type = RecipeCategory.SEAFOOD.ToString()
                    },
                    new Recipe
                    {
                        Name = "Spaghetti and Meatballs",
                        Description = "Making your sauce is always better—it's cheaper and so much more flavorful." +
                                      " This one comes together in about 15 minutes and is the perfect accompaniment to the big garlicky meatballs. ",
                        NumOfServings = 4,
                        PrepTime = 20,
                        TotalTime = 60,
                        Creator = "LENA ABRAHAM",
                        DateCreated = new DateTime(2019, 4, 19),
                        Type = RecipeCategory.PASTA.ToString()
                    },
                    new Recipe
                    {
                        Name = "Shrimp Fettuccine Alfredo",
                        Creator = "LENA ABRAHAM",
                        DateCreated = new DateTime(2018, 10, 15),
                        Description = "Fettuccine alfredo is one of life's greatest comfort foods. It's creamy, cheesy, carb-y, and super super flavorful." +
                                      " We especially love this version because the shrimp adds lots of extra flavor and some lean protein to boot!" +
                                      " Make sure to avoid the common mistakes listed below and you'll master this dish in no time.",
                        NumOfServings = 4,
                        PrepTime = 15,
                        TotalTime = 25,
                        Type = RecipeCategory.PASTA.ToString()
                    },
                    new Recipe
                    {
                        Name = "Shrimp Fettuccine Alfredo",
                        Creator = "LENA ABRAHAM",
                        DateCreated = new DateTime(2018, 10, 15),
                        Description = "Fettuccine alfredo is one of life's greatest comfort foods. It's creamy, cheesy, carb-y, and super super flavorful." +
                                      " We especially love this version because the shrimp adds lots of extra flavor and some lean protein to boot!" +
                                      " Make sure to avoid the common mistakes listed below and you'll master this dish in no time.",
                        NumOfServings = 4,
                        PrepTime = 15,
                        TotalTime = 25,
                        Type = RecipeCategory.PASTA.ToString()
                    },
                    new Recipe
                    {
                        Name = "Santa Clausmopolitans",
                        Creator = "LAUREN MIYASHIRO",
                        DateCreated = new DateTime(2019, 11, 25),
                        Description = "All of the presents are wrapped and you now deserve a Santa Clausmopolitan. " +
                                      "This fresh, tart cocktail is the perfect way to unwind from the holiday stress. ",
                        NumOfServings = 4,
                        PrepTime = 5,
                        TotalTime = 5,
                        Type = RecipeCategory.DRINK.ToString()
                    },
                    new Recipe
                    {
                        Name = "Holiday Honey & Spice",
                        Creator = "SPRITE®",
                        DateCreated = new DateTime(2019, 11, 26),
                        Description = "A spiced cocktail is just what your holidays need and this easy cocktail has the perfect balance between spice and sweet." +
                                      " Your family will think you turned into a master bartender.  ",
                        NumOfServings = 2,
                        PrepTime = 5,
                        TotalTime = 5,
                        Type = RecipeCategory.DRINK.ToString()
                    },
                    new Recipe
                    {
                        Name = "Fried Chicken Strips",
                        Creator = "KAT BOYTSOVA",
                        DateCreated = new DateTime(2019, 11, 25),
                        Description = "Ahh fried chicken strips take us right back to our childhood." +
                                      " This homemade version makes the tenders so much better and is honestly just what makes us feel better about eating them as an adult. " +
                                      "Make some homemade fries to go along with!  ",
                        NumOfServings = 4,
                        PrepTime = 10,
                        TotalTime = 45,
                        Type = RecipeCategory.CHICKEN.ToString()
                    },
                    new Recipe
                    {
                        Name = "Beef Wellington",
                        Creator = "DELISH EDITORS",
                        DateCreated = new DateTime(2019, 11, 1),
                        Description = "So, you've decided to make Beef Wellington. Congratulations!" +
                                      " You are about to make your dinner guests extremely happy. " +
                                      "While the origins of this famous dish are unknown, we do know it's a holiday showstopper that is not for the faint of heart. " +
                                      "Below, we break down all the elements of a classic Beef Wellington from the inside out, so you can fearlessly continue to make the best Wellington you can. " +
                                      "We believe in you!",
                        NumOfServings = 6,
                        PrepTime = 15,
                        TotalTime = 150,
                        Type = RecipeCategory.BEEF.ToString()
                    },
                    new Recipe
                    {
                        Name = "Beef Wellington",
                        Creator = "DELISH EDITORS",
                        DateCreated = new DateTime(2019, 11, 1),
                        Description = "So, you've decided to make Beef Wellington. Congratulations!" +
                                      " You are about to make your dinner guests extremely happy. " +
                                      "While the origins of this famous dish are unknown, we do know it's a holiday showstopper that is not for the faint of heart. " +
                                      "Below, we break down all the elements of a classic Beef Wellington from the inside out, so you can fearlessly continue to make the best Wellington you can. " +
                                      "We believe in you!",
                        NumOfServings = 6,
                        PrepTime = 15,
                        TotalTime = 150,
                        Type = RecipeCategory.BEEF.ToString()
                    },
                    new Recipe
                    {
                        Name = "Perfect Rice",
                        Creator = "NEELYS",
                        Description = String.Empty,
                        NumOfServings = 3,
                        PrepTime = 5,
                        TotalTime = 25,
                        Type = RecipeCategory.RICE.ToString()
                    }
                );

                // Save to Database
                context.SaveChanges();
            }
        }
    }
}

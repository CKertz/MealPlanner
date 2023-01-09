using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RecipeImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO:move to settings/config file
            string connectionString = "Data Source=DESKTOP-AJR49RD;Initial Catalog=MealPlannerdb;Integrated Security=True";
            handleUserChoice();
        }

        //public void getDBConnectionString(IConfiguration configuration)
        //{
        //    IConfiguration Configuration = new IConfiguration();
        //    string connStr = String.Empty;

        //    if (env.IsDevelopment())
        //    {
        //        connStr = Configuration.GetConnectionString("DevConnection");
        //    }
        //    else
        //    {
        //        connStr = Configuration.GetConnectionString("ProdConnection");
        //    }
        //}

        public static void handleUserChoice()
        {
            Console.WriteLine("Enter choice number \n 1. Add a new recipe to db \n test \n test");
            string val = Console.ReadLine();
            int consoleChoice = int.Parse(val);
            switch(consoleChoice)
            {
                case 1:
                {
                    addNewRecipeToDB();
                    break;
                }

                default:
                    break;
            }
        }

        public static void addNewRecipeToDB()
        {
            // TODO: this has not been tested and is not fully complete
            // sloppy cli thrown together for quickly adding in new recipes. lots of edge cases and error handling not accounted for so be careful
            Recipe newRecipe = getRecipeMetaData();
            Console.WriteLine("Time to enter ingredients. Begin entering using the following format, separate each entry with Enter key." +
                " Examples: \n 4 cup flour \n 3 potato");
            string ingredientInput = "";
            while (ingredientInput != "0")
            {
                ingredientInput = Console.ReadLine();
                setIngredientData(ingredientInput.Split(" "));
                Console.WriteLine("What department does this ingredient fall under? \n" +
                    "1. Meat \n 2. Dairy \n 3. Produce \n 4. Packaged Meat \n 5. Seafood \n 6. General grocery");
                int inputDepartmentNumber = int.Parse(Console.ReadLine());

                if (ingredientInput != "0")
                {
                    Console.WriteLine("Ingredient added: {0}", ingredientInput);
                }
            }      
            
            Console.WriteLine("ingredient list finished, adding the recipe for {0} to database now", newRecipe.RecipeName);

        }

        public static void setIngredientData(string[] inputData)
        {
            if (inputData.Length == 3)
            {
                //format would be 3 cup flour 
                Ingredient ingredient = new Ingredient();
                Measurement measurement = new Measurement();
                Quantity quantity = new Quantity();

                quantity.QuantityAmount = decimal.Parse(inputData[0]);
                measurement.MeasurementName = inputData[1];
                ingredient.IngredientName = inputData[2];


                quantity.Measurement = measurement;
                ingredient.Quantity = quantity;
            }
            if (inputData.Length == 2)
            {
                //format would be 6 potato
            }
        }

        public static Recipe getRecipeMetaData()
        {
            Recipe newRecipe = new Recipe();
            Console.WriteLine("Enter the name of the recipe");
            string recipeName = Console.ReadLine();
            newRecipe.RecipeName = recipeName;

            Console.WriteLine("Enter the rating for this recipe from 1 to 10. Enter 0 if N/A");
            int recipeRating = int.Parse(Console.ReadLine());
            newRecipe.Rating = recipeRating;

            Console.WriteLine("Enter the rating for this recipe from 1 to 10");
            int recipeDifficulty = int.Parse(Console.ReadLine());
            newRecipe.Difficulty = recipeDifficulty;

            Console.WriteLine("What region of food is this? Enter 0 if N/A");
            string recipeFoodType = Console.ReadLine();
            newRecipe.FoodType = recipeFoodType;

            Console.WriteLine("What season is this recipe best for? Summer/Fall/Winter/Spring. Enter 0 if N/A");
            string recipeSeason = Console.ReadLine();
            newRecipe.Season = recipeSeason;

            return newRecipe;
        }

        public static List<Recipe> getRecipes()
        {
            var recipeList = new List<Recipe>();
            using (var context = new MealPlannerdbContext())
            {
                recipeList = context.Recipe.OrderBy(b => b.RecipeId).ToList();
            }
            return recipeList;
        }

        //public static void testfunc()
        //{
        //    using (var context = new MealPlannerdbContext())
        //    {
        //        var test = context.Measurement.OrderBy(b => b.MeasurementId).ToList();

        //        //var students = (from s in context.Recipe
        //        //                where s. == "Bill"
        //        //                select s).ToList();
        //        //var ingredients = context.Ingredient.
        //        ////Log DB commands to console
        //        //context.Database.Log = Console.WriteLine;

        //        ////Add a new student and address
        //        //var newStudent = context.Students.Add(new Student() { StudentName = "Jonathan", StudentAddress = new StudentAddress() { Address1 = "1, Harbourside", City = "Jersey City", State = "NJ" } });
        //        //context.SaveChanges(); // Executes Insert command

        //        ////Edit student name
        //        //newStudent.StudentName = "Alex";
        //        //context.SaveChanges(); // Executes Update command

        //        ////Remove student
        //        //context.Students.Remove(newStudent);
        //        //context.SaveChanges(); // Executes Delete command
        //    }
        //}


        //public static async void getRecipesOld(string connectionString)
        //{

        //    List<Recipe> aListOfItems = new List<Recipe>();

        //    string commandText = @"SELECT * FROM [MealPlannerdb].[dbo].[Recipe]";

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();   //vs  connection.Open();
        //        using (var tran = connection.BeginTransaction())
        //        {
        //            using (var command = new SqlCommand(commandText, connection, tran))
        //            {
        //                try
        //                {
        //                    //command.Parameters.Add("@SUBMITTEREMAIL", SqlDbType.NVarChar);
        //                    //command.Parameters["@SUBMITTEREMAIL"].Value = "me@someDomain.org";

        //                    SqlDataReader rdr = command.ExecuteReader();  // vs also alternatives, command.ExecuteReader();  or await command.ExecuteNonQueryAsync();

        //                    while (rdr.Read())
        //                    {
        //                        var itemContent = new Recipe();
        //                        itemContent.RecipeName = rdr["RecipeName"].ToString();
        //                        itemContent.LastMade = (DateTime?)rdr["LastMade"];
        //                        itemContent.Rating = (int?)rdr["Rating"];
        //                        itemContent.FoodType = rdr["FoodType"].ToString();
        //                        itemContent.Difficulty = (int?)rdr["Difficulty"];
        //                        itemContent.InSeason = (bool?)rdr["InSeason"];

        //                        aListOfItems.Add(itemContent);
        //                    }
        //                    await rdr.CloseAsync();
        //                }
        //                catch (Exception Ex)
        //                {
        //                    await connection.CloseAsync();
        //                    string msg = Ex.Message.ToString();
        //                    tran.Rollback();
        //                    throw;
        //                }
        //            }
        //        }
        //    }

        //    //string totalinfo = string.Empty;
        //    //foreach (var itm in aListOfItems)
        //    //{
        //    //    totalinfo = totalinfo + itm.UserName + itm.References + itm.CreatedTime;
        //    //}
        //    //return Content(totalinfo);

        //}
    }
}

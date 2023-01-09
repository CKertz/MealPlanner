using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeImporter.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public long RecipeId { get; set; }
        public string RecipeName { get; set; }
        public DateTime? LastMade { get; set; }
        public int? Rating { get; set; }
        public string FoodType { get; set; }
        public int? Difficulty { get; set; }
        public bool? InSeason { get; set; }
        public string? Season { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}

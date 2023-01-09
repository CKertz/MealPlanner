using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeImporter.Models
{
    public partial class Ingredient
    {
        public long IngredientId { get; set; }
        public string IngredientName { get; set; }
        public long? QuantityId { get; set; }
        public long? DepartmentId { get; set; }
        public long? RecipeId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Quantity Quantity { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}

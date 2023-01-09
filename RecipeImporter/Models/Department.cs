using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeImporter.Models
{
    public partial class Department
    {
        public Department()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}

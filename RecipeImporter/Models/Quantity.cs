using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeImporter.Models
{
    public partial class Quantity
    {
        public Quantity()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public long QuantityId { get; set; }
        public decimal? QuantityAmount { get; set; }
        public long? MeasurementId { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeImporter.Models
{
    public partial class Measurement
    {
        public Measurement()
        {
            Quantity = new HashSet<Quantity>();
        }

        public long MeasurementId { get; set; }
        public string MeasurementName { get; set; }

        public virtual ICollection<Quantity> Quantity { get; set; }
    }
}

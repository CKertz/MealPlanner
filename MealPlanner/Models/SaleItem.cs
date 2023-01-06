using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.WebScraper.Models
{
    class SaleItem
    {
        public double itemPrice { get; set; }
        public String itemName { get; set; }

        // move to enums?
        public String departmentName { get; set; }
        public String quantityType { get; set; }

        // if an item is 2/$4, forQuanitityNumber is 2
        public int forQuanitityNumber;

        public SaleItem() { }
        public SaleItem(double price, String itemName)
        {
            itemPrice = price;
            this.itemName = itemName;
        }
    }
}

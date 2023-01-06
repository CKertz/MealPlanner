using MealPlanner.WebScraper.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealPlanner.WebScraper
{
    class ScraperHelper
    {
        public int getSaleItemCount(WebDriver driver)
        {
            return driver.FindElements(By.XPath("//*[@id='grid-items']/div")).Count;
        }

        public void formatSaleItemPrice(String saleItemPriceRawData, SaleItem saleItem)
        {
            //5 main price format examples:
            //2/$2
            //$1999ea
            //$399ea
            //$299lb
            //$1off
            //$750 ea

            String oldPrice = saleItemPriceRawData;

            if (oldPrice.Contains("off"))
            {
                saleItem.quantityType = "coupon";
                return;
            }

            if (oldPrice.Contains("/"))
            {
                double newPrice = Double.Parse(oldPrice.Substring(oldPrice.Length - 1));
                saleItem.itemPrice = newPrice;
                saleItem.quantityType = "for";
                saleItem.forQuanitityNumber = (Int32.Parse(oldPrice.Substring(0, 1)));
                return;
            }

            if (oldPrice.Contains("ea"))
            {
                if(oldPrice.Contains(" ea"))
                {
                    // weird case that sometimes pops up. just reformatting it to happy path and moving on
                    oldPrice = oldPrice.Replace(" ", "");
                }
                // add decimal to the string, parse it to int after by trimming the $
                oldPrice = oldPrice.Substring(0, oldPrice.Length - 3);
                oldPrice = new StringBuilder(oldPrice).Insert(oldPrice.Length - 2, ".").ToString();
                double newPrice = Double.Parse(oldPrice.Substring(1));

                saleItem.itemPrice = newPrice;
                saleItem.quantityType = "ea";
                return;
            }

            if (oldPrice.Contains("lb"))
            {
                // add decimal to the string, parse it to int after by trimming the $
                oldPrice = oldPrice.Substring(0, oldPrice.Length - 3);
                oldPrice = new StringBuilder(oldPrice).Insert(oldPrice.Length - 2, ".").ToString();
                double newPrice = Double.Parse(oldPrice.Substring(1));

                saleItem.itemPrice = newPrice;
                saleItem.quantityType = "lb";
                return;
            }
        }
    }
}

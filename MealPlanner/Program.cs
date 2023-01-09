using MealPlanner.WebScraper;
using MealPlanner.WebScraper.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace MealPlanner
{
    static class Program
    {
        static void Main(string[] args)
        {
            ScraperHelper scraperHelper = new WebScraper.ScraperHelper();
            //Program scraper = new Program();  
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.mypricechopper.com/savings/weekly-ad");

            var preferredStoreXPath = "/html/body/content-wrapper/div[2]/div/div/div[2]/div[3]/div[1]/div[1]/div/div[2]/div[2]/button";
            driver.FindElement(By.XPath(preferredStoreXPath)).Click();

            var acceptCookiesXPath = "/html/body/div[1]/div/a";
            driver.FindElement(By.XPath(acceptCookiesXPath)).Click();

            System.Threading.Thread.Sleep(3000);

            List<SaleItem> meatOnSale = getMeatSaleItems(driver, scraperHelper);
            List<SaleItem> produceOnSale = getProduceSaleItems(driver, scraperHelper);
            List<SaleItem> dairyOnSale = getDairySaleItems(driver, scraperHelper);
            List<SaleItem> packagedMeatOnSale = getPackagedMeatSaleItems(driver, scraperHelper);
            List<SaleItem> groceryOnSale = getGrocerySaleItems(driver, scraperHelper);
            List<SaleItem> seafoodOnSale = getSeafoodSaleItems(driver, scraperHelper);

            driver.Close();
        }

        public static List<SaleItem> getMeatSaleItems(WebDriver driver, ScraperHelper scraperHelper)
        {
            // filter out meat items by clicking the checkbox and then collect the filtered items
            var meatItemCheckboxXPath = "/html/body/content-wrapper/div[3]/div[3]/div[2]/div[2]/div[4]/div[1]/div/div[2]/div[2]/div/div[3]/label";
            driver.FindElement(By.XPath(meatItemCheckboxXPath)).Click();

            int meatSaleItemCount = scraperHelper.getSaleItemCount(driver);

            var meatItems = getSaleItemsFromGrid(driver, meatSaleItemCount, "Meat", scraperHelper);
            driver.FindElement(By.XPath(meatItemCheckboxXPath)).Click();
            return meatItems;
        }

        public static List<SaleItem> getProduceSaleItems(WebDriver driver, ScraperHelper scraperHelper)
        {
            var produceItemCheckboxXPath = "/html/body/content-wrapper/div[3]/div[3]/div[2]/div[2]/div[4]/div[1]/div/div[2]/div[2]/div/div[4]/label";
            driver.FindElement(By.XPath(produceItemCheckboxXPath)).Click();

            int produceSaleItemCount = scraperHelper.getSaleItemCount(driver);

            var produceItems = getSaleItemsFromGrid(driver, produceSaleItemCount, "Produce", scraperHelper);
            driver.FindElement(By.XPath(produceItemCheckboxXPath)).Click();
            return produceItems;
        }

        public static List<SaleItem> getDairySaleItems(WebDriver driver, ScraperHelper scraperHelper)
        {
            var dairyItemCheckboxXPath = "/html/body/content-wrapper/div[3]/div[3]/div[2]/div[2]/div[4]/div[1]/div/div[2]/div[2]/div/div[6]/label";
            driver.FindElement(By.XPath(dairyItemCheckboxXPath)).Click();

            int produceSaleItemCount = scraperHelper.getSaleItemCount(driver);

            var dairyItems = getSaleItemsFromGrid(driver, produceSaleItemCount, "Dairy", scraperHelper);
            driver.FindElement(By.XPath(dairyItemCheckboxXPath)).Click();
            return dairyItems;
        }

        public static List<SaleItem> getPackagedMeatSaleItems(WebDriver driver, ScraperHelper scraperHelper)
        {
            var packedMeatItemCheckboxXPath = "/html/body/content-wrapper/div[3]/div[3]/div[2]/div[2]/div[4]/div[1]/div/div[2]/div[2]/div/div[7]/label";
            driver.FindElement(By.XPath(packedMeatItemCheckboxXPath)).Click();

            int packagedMeatSaleItemCount = scraperHelper.getSaleItemCount(driver);

            var packagedMeatItems = getSaleItemsFromGrid(driver, packagedMeatSaleItemCount, "PackagedMeat", scraperHelper);
            driver.FindElement(By.XPath(packedMeatItemCheckboxXPath)).Click();
            return packagedMeatItems;
        }

        public static List<SaleItem> getGrocerySaleItems(WebDriver driver, ScraperHelper scraperHelper)
        {
            var groceryItemCheckboxXPath = "/html/body/content-wrapper/div[3]/div[3]/div[2]/div[2]/div[4]/div[1]/div/div[2]/div[2]/div/div[5]/label";
            driver.FindElement(By.XPath(groceryItemCheckboxXPath)).Click();

            int grocerySaleItemCount = scraperHelper.getSaleItemCount(driver);

            var groceryItems = getSaleItemsFromGrid(driver, grocerySaleItemCount, "Grocery", scraperHelper);
            driver.FindElement(By.XPath(groceryItemCheckboxXPath)).Click();
            return groceryItems;
        }

        public static List<SaleItem> getSeafoodSaleItems(WebDriver driver, ScraperHelper scraperHelper)
        {
            var seafoodItemCheckboxXPath = "/html/body/content-wrapper/div[3]/div[3]/div[2]/div[2]/div[4]/div[1]/div/div[2]/div[2]/div/div[8]/label";
            driver.FindElement(By.XPath(seafoodItemCheckboxXPath)).Click();

            int seafoodSaleItemCount = scraperHelper.getSaleItemCount(driver);

            var seafoodItems = getSaleItemsFromGrid(driver, seafoodSaleItemCount, "Seafood", scraperHelper);
            driver.FindElement(By.XPath(seafoodItemCheckboxXPath)).Click();
            return seafoodItems;
        }

        public static List<SaleItem> getSaleItemsFromGrid(WebDriver driver, int saleItemCount, String departmentName, ScraperHelper scraperHelper)
        {
            List<SaleItem> saleItems = new List<SaleItem>();

            for (int i = 1; i <= saleItemCount; i++)
            {
                //the line below may be wrong, altered it a bit from java
                var saleItemData = driver.FindElement(By.XPath("//div[contains(@class, 'grid-product')][" + i + "]/div[1]")).Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

                SaleItem currentSaleItem = new SaleItem();
                scraperHelper.formatSaleItemPrice(saleItemData[0], currentSaleItem);
                currentSaleItem.itemName = saleItemData[1];
                if (departmentName != null)
                {
                    currentSaleItem.departmentName = departmentName;
                }
                saleItems.Add(currentSaleItem);
            }
            return saleItems;
        }
    }
}

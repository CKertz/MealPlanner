package com.example.MealPlanner.Service;

import com.example.MealPlanner.WebScraper.Models.Enums.Department;
import com.example.MealPlanner.WebScraper.Models.Enums.SaleItemSuffix;
import com.example.MealPlanner.WebScraper.Models.SaleItem;
import com.example.MealPlanner.WebScraper.WebScraper;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@Service
public class SaleItemService
{
    private final WebDriver driver;

    @Autowired
    public SaleItemService(WebScraper webScraper)
    {
        this.driver = webScraper.setupWebScraper();
    }

    public List<List<SaleItem>> getAllSaleItemLists()
    {
        var meatSaleItems = getMeatSaleItems();
        var seafoodSaleItems = getSeafoodSaleItems();
        var packagedMeatSaleItems = getPackagedMeatSaleItems();
        var dairySaleItems = getDairySaleItems();
        var grocerySaleItems = getGrocerySaleItems();
        var produceSaleItems = getProduceSaleItems();

        return Arrays.asList(meatSaleItems,seafoodSaleItems,packagedMeatSaleItems, dairySaleItems,grocerySaleItems,produceSaleItems);
    }

    public List<SaleItem> getMeatSaleItems()
    {
        driver.findElement(By.linkText("Meat - Fresh Cut")).click();

        try {
            Thread.sleep(3000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        int meatSaleItemCount = getSaleItemCount();

        return getSaleItemsFromGrid(meatSaleItemCount, Department.Meat);
    }

    public List<SaleItem> getSeafoodSaleItems()
    {
        driver.findElement(By.linkText("Seafood")).click();
        int seafoodSaleItemCount = getSaleItemCount();

        return getSaleItemsFromGrid(seafoodSaleItemCount, Department.Seafood);
    }

    public List<SaleItem> getDairySaleItems()
    {
        driver.findElement(By.linkText("Dairy")).click();
        int dairySaleItemCount = getSaleItemCount();

        return getSaleItemsFromGrid(dairySaleItemCount, Department.Dairy);
    }

    public List<SaleItem> getProduceSaleItems()
    {
        driver.findElement(By.linkText("Produce")).click();
        int produceSaleItemCount = getSaleItemCount();

        return getSaleItemsFromGrid(produceSaleItemCount, Department.Produce);
    }

    public List<SaleItem> getGrocerySaleItems()
    {
        driver.findElement(By.linkText("Grocery")).click();
        int grocerySaleItemCount = getSaleItemCount();

        return getSaleItemsFromGrid(grocerySaleItemCount, Department.Grocery);
    }

    public List<SaleItem> getPackagedMeatSaleItems()
    {
        driver.findElement(By.linkText("Meat - Packaged")).click();
        int packagedMeatSaleItemCount = getSaleItemCount();

        return getSaleItemsFromGrid(packagedMeatSaleItemCount, Department.PackagedMeat);
    }


    public int getSaleItemCount()
    {
        return driver.findElements(By.xpath("//*[@id='grid-items']/div")).size();
    }

    public List<SaleItem> getSaleItemsFromGrid(int saleItemNumber, Department departmentName)
    {
        List<SaleItem> saleItems = new ArrayList<>();
        for (int i = 1; i <= saleItemNumber; i++)
        {
            String[] saleItemData =  driver.findElement(By.xpath("//div[contains(@class, 'grid-product')]["+i+"]/div[1]")).getText().split("\\R");

            SaleItem currentSaleItem = new SaleItem();
            formatSaleItemPrice(saleItemData[0],currentSaleItem);
            currentSaleItem.setItemName(saleItemData[1]);
            if (departmentName != null)
            {
                currentSaleItem.setDepartmentName(departmentName);
            }
            saleItems.add(currentSaleItem);
        }
        return saleItems;
    }

    public void formatSaleItemPrice(String saleItemPriceRawData, SaleItem saleItem)
    {
        //4 main price format examples:
        //2/$2
        //$1999ea
        //$399ea
        //$299lb
        //$1off

        String oldPrice = saleItemPriceRawData;

        if(oldPrice.contains("off"))
        {
            saleItem.setSaleItemSuffix(SaleItemSuffix.OFF);
            return;
        }

        if(oldPrice.contains("/"))
        {
            double newPrice = Double.parseDouble(oldPrice.substring(oldPrice.length()-1));
            saleItem.setPrice(newPrice);
            saleItem.setSaleItemSuffix(SaleItemSuffix.FOR);
            saleItem.setForQuantityNumber(Integer.parseInt(oldPrice.substring(0,1)));
            return;
        }

        if(oldPrice.contains("ea"))
        {
            // add decimal to the string, parse it to int after by trimming the $
            oldPrice = oldPrice.substring(0,oldPrice.length()-3);
            oldPrice = new StringBuilder(oldPrice).insert(oldPrice.length()-2,".").toString();
            double newPrice = Double.parseDouble(oldPrice.substring(1));

            saleItem.setPrice(newPrice);
            saleItem.setSaleItemSuffix(SaleItemSuffix.EACH);
            return;
        }

        if(oldPrice.contains("lb"))
        {
            // add decimal to the string, parse it to int after by trimming the $
            oldPrice = oldPrice.substring(0,oldPrice.length()-3);
            oldPrice = new StringBuilder(oldPrice).insert(oldPrice.length()-2,".").toString();
            double newPrice = Double.parseDouble(oldPrice.substring(1));

            saleItem.setPrice(newPrice);
            saleItem.setSaleItemSuffix(SaleItemSuffix.LB);
            return;
        }
    }

}

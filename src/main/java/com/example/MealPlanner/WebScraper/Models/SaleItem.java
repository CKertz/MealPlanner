package com.example.MealPlanner.WebScraper.Models;

import com.example.MealPlanner.WebScraper.Models.Enums.Department;
import com.example.MealPlanner.WebScraper.Models.Enums.SaleItemSuffix;

public class SaleItem {
    private double price;
    private String itemName;
    private Department departmentName;
    private SaleItemSuffix saleItemSuffix;
    // if an item is 2/$4, forQuantityNumber is 2
    private int forQuantityNumber;

    public SaleItem() {}

    public SaleItem(double price, String itemName)
    {
        this.price = price;
        this.itemName = itemName;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public String getItemName() { return itemName; }

    public void setItemName(String itemName) {
        this.itemName = itemName;
    }

    public Department getDepartmentName() {
        return departmentName;
    }

    public void setDepartmentName(Department departmentName) {
        this.departmentName = departmentName;
    }

    public SaleItemSuffix getSaleItemSuffix() {
        return saleItemSuffix;
    }

    public void setSaleItemSuffix(SaleItemSuffix saleItemSuffix) {
        this.saleItemSuffix = saleItemSuffix;
    }

    public int getForQuantityNumber() {
        return forQuantityNumber;
    }

    public void setForQuantityNumber(int forQuantityNumber) {
        this.forQuantityNumber = forQuantityNumber;
    }
}
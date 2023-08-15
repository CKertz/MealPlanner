package com.example.MealPlanner;

import com.example.MealPlanner.WebScraper.Models.SaleItem;
import com.example.MealPlanner.WebScraper.WebScraper;
import com.example.MealPlanner.Service.SaleItemService;
import org.openqa.selenium.WebDriver;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/saleitem")
public class SaleItemController
{
    private final SaleItemService saleItemService;

    public SaleItemController(SaleItemService saleItemService)
    {
        this.saleItemService = saleItemService;
    }

    @GetMapping("/all")
    public ResponseEntity<List<List<SaleItem>>> getallSaleItems()
    {
        List<List<SaleItem>> saleItems = saleItemService.getAllSaleItemLists();
        return new ResponseEntity<>(saleItems, HttpStatus.OK);
    }
    @GetMapping("/meat")
    public ResponseEntity<List<SaleItem>> getMeatSaleItems()
    {
        List<SaleItem> saleItems = saleItemService.getMeatSaleItems();
        return new ResponseEntity<>(saleItems, HttpStatus.OK);
    }

    @GetMapping("/seafood")
    public ResponseEntity<List<SaleItem>> getSeafoodSaleItems()
    {
        List<SaleItem> saleItems = saleItemService.getSeafoodSaleItems();
        return new ResponseEntity<>(saleItems, HttpStatus.OK);
    }

    @GetMapping("/packagedmeat")
    public ResponseEntity<List<SaleItem>> getPackagedMeatSaleItems()
    {
        List<SaleItem> saleItems = saleItemService.getPackagedMeatSaleItems();
        return new ResponseEntity<>(saleItems, HttpStatus.OK);
    }

}

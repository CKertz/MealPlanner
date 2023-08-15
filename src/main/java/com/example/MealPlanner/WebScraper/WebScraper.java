package com.example.MealPlanner.WebScraper;
import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.springframework.stereotype.Component;

@Component
public class WebScraper
{

//    public static void main(String[] args)
//    {
//        setupWebScraper();
//    }

    public static WebDriver setupWebScraper()
    {
        WebDriver driver = new ChromeDriver();

        driver.manage().window().maximize();
        driver.get("https://www.mypricechopper.com/savings/weekly-ad");

        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        var preferredStoreXPath = "/html/body/content-wrapper/div[2]/div/div/div[2]/div[3]/div[1]/div[1]/div/div[2]/div[2]/button";
        driver.findElement(By.xpath(preferredStoreXPath)).click();

        try {
            Thread.sleep(2000);
        } catch (InterruptedException e) {
            e.printStackTrace();
        }

        JavascriptExecutor js = (JavascriptExecutor) driver;
        js.executeScript("window.scrollBy(0,500)");

        return driver;
    }


}

package com.example.MealPlanner.Controllers;

import com.example.MealPlanner.Models.Recipe;
import com.example.MealPlanner.Services.RecipeService;
import com.example.MealPlanner.Services.SaleItemService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/recipe")
public class RecipeController
{
    private final RecipeService recipeService;

    public RecipeController(RecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    @PostMapping("/submit")
    public ResponseEntity<Recipe> addRecipe(@RequestBody Recipe recipeToAdd)
    {
        Recipe recipe = recipeService.addRecipe(recipeToAdd);
        return new ResponseEntity<>(recipe, HttpStatus.CREATED);
    }

}

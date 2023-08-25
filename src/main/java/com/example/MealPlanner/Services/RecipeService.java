package com.example.MealPlanner.Services;

import com.example.MealPlanner.Models.Recipe;
import com.example.MealPlanner.Repositories.IRecipeRepo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RecipeService
{
    private final IRecipeRepo recipeRepo;
    @Autowired
    public RecipeService(IRecipeRepo recipeRepo) { this.recipeRepo = recipeRepo; }
    public Recipe addRecipe(Recipe recipe)
    {

        return recipeRepo.save(recipe);
    }
}

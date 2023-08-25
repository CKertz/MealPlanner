package com.example.MealPlanner.Repositories;

import com.example.MealPlanner.Models.Recipe;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IRecipeRepo extends JpaRepository<Recipe, Long>
{

}

package com.example.MealPlanner.Models;

import jakarta.persistence.*;

import java.io.Serializable;

@Entity
public class Ingredient implements Serializable
{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long Id;
    private String ingredientName;
    @ManyToOne
    private Quantity quantity;
    @ManyToOne
    private Department department;
    @OneToOne
    private Recipe recipe;

    public Ingredient(Long ingredientId, String ingredientName, Quantity quantity, Department department, Recipe recipe) {
        this.Id = ingredientId;
        this.ingredientName = ingredientName;
        this.quantity = quantity;
        this.department = department;
        this.recipe = recipe;
    }

    public Long getIngredientId() {
        return Id;
    }

    public void setIngredientId(Long ingredientId) {
        this.Id = ingredientId;
    }

    public String getIngredientName() {
        return ingredientName;
    }

    public void setIngredientName(String ingredientName) {
        this.ingredientName = ingredientName;
    }

    public Quantity getQuantity() {
        return quantity;
    }

    public void setQuantity(Quantity quantity) {
        this.quantity = quantity;
    }

    public Recipe getRecipe() {
        return recipe;
    }

    public void setRecipe(Recipe recipe) {
        this.recipe = recipe;
    }

    public Department getDepartment() {
        return department;
    }

    public void setDepartment(Department department) {
        this.department = department;
    }
}

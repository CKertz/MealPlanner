package com.example.MealPlanner.Models;

import jakarta.persistence.Column;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

import java.sql.Date;

public class Recipe
{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long recipeId;
    @Column(nullable = false)
    private String recipeName;
    private Date lastMadeOn;
    private int rating;
    private String region;
    private int difficulty;
    private String season;

    public Recipe(Long recipeId, String recipeName, Date lastMadeOn, int rating, String region, int difficulty, String season) {
        this.recipeId = recipeId;
        this.recipeName = recipeName;
        this.lastMadeOn = lastMadeOn;
        this.rating = rating;
        this.region = region;
        this.difficulty = difficulty;
        this.season = season;
    }

    public Long getRecipeId() {
        return recipeId;
    }

    public void setRecipeId(Long recipeId) {
        this.recipeId = recipeId;
    }

    public String getRecipeName() {
        return recipeName;
    }

    public void setRecipeName(String recipeName) {
        this.recipeName = recipeName;
    }

    public Date getLastMadeOn() {
        return lastMadeOn;
    }

    public void setLastMadeOn(Date lastMadeOn) {
        this.lastMadeOn = lastMadeOn;
    }

    public int getRating() {
        return rating;
    }

    public void setRating(int rating) {
        this.rating = rating;
    }

    public String getRegion() {
        return region;
    }

    public void setRegion(String region) {
        this.region = region;
    }

    public int getDifficulty() {
        return difficulty;
    }

    public void setDifficulty(int difficulty) {
        this.difficulty = difficulty;
    }

    public String getSeason() {
        return season;
    }

    public void setSeason(String season) {
        this.season = season;
    }
}

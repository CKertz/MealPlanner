package com.example.MealPlanner.Models;

import jakarta.persistence.*;

public class Quantity
{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long quantityId;
    private float quantityAmount;
    @ManyToOne
    private Long measurementId;

    public Quantity(Long quantityId, float quantityAmount, Long measurementId) {
        this.quantityId = quantityId;
        this.quantityAmount = quantityAmount;
        this.measurementId = measurementId;
    }

    public Long getQuantityId() {
        return quantityId;
    }

    public void setQuantityId(Long quantityId) {
        this.quantityId = quantityId;
    }

    public float getQuantityAmount() {
        return quantityAmount;
    }

    public void setQuantityAmount(float quantityAmount) {
        this.quantityAmount = quantityAmount;
    }

    public Long getMeasurementId() {
        return measurementId;
    }

    public void setMeasurementId(Long measurementId) {
        this.measurementId = measurementId;
    }
}

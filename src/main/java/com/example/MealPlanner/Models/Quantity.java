package com.example.MealPlanner.Models;

import jakarta.persistence.*;

import java.io.Serializable;

@Entity
public class Quantity implements Serializable
{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long Id;
    private float quantityAmount;
    @ManyToOne
    private Measurement measurement;

    public Quantity(Long quantityId, float quantityAmount, Measurement measurementId) {
        this.Id = quantityId;
        this.quantityAmount = quantityAmount;
        this.measurement = measurement;
    }

    public Long getQuantityId() {
        return Id;
    }

    public void setQuantityId(Long quantityId) {
        this.Id = quantityId;
    }

    public float getQuantityAmount() {
        return quantityAmount;
    }

    public void setQuantityAmount(float quantityAmount) {
        this.quantityAmount = quantityAmount;
    }

    public Measurement getMeasurement() {
        return measurement;
    }

    public void setMeasurement(Measurement measurement) {
        this.measurement = measurement;
    }
}

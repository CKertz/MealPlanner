package com.example.MealPlanner.Models;

import jakarta.persistence.*;

import java.io.Serializable;

@Entity
public class Measurement implements Serializable
{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long Id;
    private String measurementName;

    public Measurement(Long measurementId, String measurementName) {
        this.Id = measurementId;
        this.measurementName = measurementName;
    }

    public Long getMeasurementId() {
        return Id;
    }

    public void setMeasurementId(Long measurementId) {
        this.Id = measurementId;
    }

    public String getMeasurementName() {
        return measurementName;
    }

    public void setMeasurementName(String measurementName) {
        this.measurementName = measurementName;
    }
}

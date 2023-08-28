package com.example.MealPlanner.Models;

import jakarta.persistence.*;

import java.io.Serializable;

@Entity
public class Department implements Serializable
{
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(nullable = false, updatable = false)
    private Long Id;
    private String departmentName;

    public Department(Long Id, String departmentName) {
        this.Id = Id;
        this.departmentName = departmentName;
    }

    public Long getDepartmentId() {
        return Id;
    }

    public void setDepartmentId(Long departmentId) {
        this.Id = departmentId;
    }

    public String getDepartmentName() {
        return departmentName;
    }

    public void setDepartmentName(String departmentName) {
        //TODO: parse a department Enum for validation
        this.departmentName = departmentName;
    }
}

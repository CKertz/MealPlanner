using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecipeImporter.Models
{
    public partial class MealPlannerdbContext : DbContext
    {
        public MealPlannerdbContext()
        {
        }

        public MealPlannerdbContext(DbContextOptions<MealPlannerdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Quantity> Quantity { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AJR49RD;Database=MealPlannerdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK_DepartmentID")
                    .IsClustered(false);

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("PK_IngredientID")
                    .IsClustered(false);

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.QuantityId).HasColumnName("QuantityID");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_DepartmentID");

                entity.HasOne(d => d.Quantity)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.QuantityId)
                    .HasConstraintName("FK_QuantityID");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK_RecipeID");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasKey(e => e.MeasurementId)
                    .HasName("PK_MeasurementID")
                    .IsClustered(false);

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.MeasurementName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quantity>(entity =>
            {
                entity.HasKey(e => e.QuantityId)
                    .HasName("PK_QuantityID")
                    .IsClustered(false);

                entity.Property(e => e.QuantityId).HasColumnName("QuantityID");

                entity.Property(e => e.MeasurementId).HasColumnName("MeasurementID");

                entity.Property(e => e.QuantityAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.Quantity)
                    .HasForeignKey(d => d.MeasurementId)
                    .HasConstraintName("FK_MeasurementID");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.RecipeId)
                    .HasName("PK_RecipeID")
                    .IsClustered(false);

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.FoodType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastMade).HasColumnType("datetime");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

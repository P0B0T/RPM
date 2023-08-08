using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pract20;

public partial class CarRepairContext : DbContext
{
    public CarRepairContext()
    {
    }

    public CarRepairContext(DbContextOptions<CarRepairContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DirectoryOfPerformersOfWork> DirectoryOfPerformersOfWorks { get; set; }

    public virtual DbSet<DirectoryOfTypesOfWork> DirectoryOfTypesOfWorks { get; set; }

    public virtual DbSet<InformationAboutPerformer> InformationAboutPerformers { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Car_repair;TrustServerCertificate=true;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DirectoryOfPerformersOfWork>(entity =>
        {
            entity.HasKey(e => e.IdArtists);

            entity.ToTable("Directory_of_performers_of_works");

            entity.Property(e => e.IdArtists).HasColumnName("Id_artists");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full_name");
        });

        modelBuilder.Entity<DirectoryOfTypesOfWork>(entity =>
        {
            entity.HasKey(e => e.IdWork);

            entity.ToTable("Directory_of_types_of_work");

            entity.Property(e => e.IdWork).HasColumnName("Id_work");
            entity.Property(e => e.CarBrand)
                .HasMaxLength(50)
                .HasColumnName("Car_brand");
            entity.Property(e => e.CostOfWork)
                .HasColumnType("money")
                .HasColumnName("Cost_of_work");
            entity.Property(e => e.NameOfTheWork)
                .HasMaxLength(50)
                .HasColumnName("Name_of_the_work");
        });

        modelBuilder.Entity<InformationAboutPerformer>(entity =>
        {
            entity.ToTable("Information_about_performers");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full_name");
            entity.Property(e => e.IdArtists).HasColumnName("Id_artists");
            entity.Property(e => e.Telephone).HasMaxLength(50);

            entity.HasOne(d => d.IdArtistsNavigation).WithMany(p => p.InformationAboutPerformers)
                .HasForeignKey(d => d.IdArtists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Information_about_performers_Directory_of_performers_of_works1");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.OrderNumber);

            entity.Property(e => e.OrderNumber).HasColumnName("Order_number");
            entity.Property(e => e.CarBrand)
                .HasMaxLength(50)
                .HasColumnName("Car_brand");
            entity.Property(e => e.Client).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.IdArtists).HasColumnName("Id_artists");
            entity.Property(e => e.IdOfTheTypeOfWork).HasColumnName("Id_of_the_type_of_work");

            entity.HasOne(d => d.IdArtistsNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdArtists)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Directory_of_performers_of_works1");

            entity.HasOne(d => d.IdOfTheTypeOfWorkNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdOfTheTypeOfWork)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Directory_of_types_of_work");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

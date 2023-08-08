using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pract18.DataBase;

public partial class SportsVeteransContext : DbContext
{
    public SportsVeteransContext()
    {
        Database.EnsureCreated();
    }

    public SportsVeteransContext(DbContextOptions<SportsVeteransContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Athlete> Athletes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Sports veterans;TrustServerCertificate=true;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.Property(e => e.AgeGroup)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("Age group");
            entity.Property(e => e.AthleteSFullName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Athlete's full name");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Hotel)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NumberOfSeats).HasColumnName("Number of seats");
            entity.Property(e => e.RoomNumber).HasColumnName("Room number");
            entity.Property(e => e.SportTipe)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Sport tipe");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Pract18;

public partial class SportsVeterans : DbContext
{
    public SportsVeterans()
    {
    }

    public virtual DbSet<Athlete> Athletes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Sports veterans;TrustServerCertificate=true;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.Property(e => e.AgeGroup)
                .HasMaxLength(20)
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

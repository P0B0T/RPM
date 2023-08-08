using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pract22.Database;

public partial class ИнформацияОСтранахContext : DbContext
{
    public ИнформацияОСтранахContext()
    {
    }

    public ИнформацияОСтранахContext(DbContextOptions<ИнформацияОСтранахContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Role { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<Страны> Страны { get; set; }

    public virtual DbSet<ЭтническийСостав> ЭтническийСостав { get; set; }

    public virtual DbSet<Языки> Языки { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Информация о странах;TrustServerCertificate=true;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Role)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Страны>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Страны");

            entity.Property(e => e.КоличествоЖителей).HasColumnName("Количество_жителей");
            entity.Property(e => e.Материк).HasMaxLength(50);
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.Столица).HasMaxLength(50);
            entity.Property(e => e.ФотоСтраны)
                .HasMaxLength(50)
                .HasColumnName("Фото_страны");
        });

        modelBuilder.Entity<ЭтническийСостав>(entity =>
        {
            entity.HasKey(e => new { e.Страна, e.Язык, e.Год });

            entity.ToTable("ЭтническийСостав");

            entity.HasOne(d => d.СтранаNavigation).WithMany(p => p.ЭтническийСостав)
                .HasForeignKey(d => d.Страна)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ЭтническийСостав_Страны");

            entity.HasOne(d => d.ЯзыкNavigation).WithMany(p => p.ЭтническийСостав)
                .HasForeignKey(d => d.Язык)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ЭтническийСостав_Языки");
        });

        modelBuilder.Entity<Языки>(entity =>
        {
            entity.HasKey(e => e.Код);

            entity.ToTable("Языки");

            entity.Property(e => e.ВидЗнаковойСистемы)
                .HasMaxLength(50)
                .HasColumnName("Вид_знаковой_системы");
            entity.Property(e => e.Название).HasMaxLength(50);
            entity.Property(e => e.ЯзыковаяГруппа)
                .HasMaxLength(50)
                .HasColumnName("Языковая_группа");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

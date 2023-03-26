using System;
using System.Collections.Generic;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public partial class AirplaneDB : DbContext
{
    public AirplaneDB()
    {
    }

    public AirplaneDB(DbContextOptions<AirplaneDB> options)
        : base(options)
    {
    }

    public virtual DbSet<BrandEnum> BrandEnums { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Logger> Loggers { get; set; }

    public virtual DbSet<Terminal> Terminals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Airplane_DataBase;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BrandEnum>(entity =>
        {
            entity.HasKey(e => e.Brand).HasName("PK__BrandEnu__BAB741D66AB6B66E");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.FlId).HasName("PK__Flight__320C53801A7218DD");

            entity.Property(e => e.FlId).ValueGeneratedNever();

            entity.HasOne(d => d.Ter).WithMany(p => p.Flights).HasConstraintName("FK__Flight__TerId__3F466844");
        });

        modelBuilder.Entity<Logger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Logger__3214EC07EF1569F3");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Terminal>(entity =>
        {
            entity.HasKey(e => e.TerId).HasName("PK__Terminal__6C716C1B65AC711F");

            entity.Property(e => e.TerId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
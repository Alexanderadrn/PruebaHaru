using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaHaru.Models;

public partial class PruebaHaruContext : DbContext
{
    public PruebaHaruContext()
    {
    }

    public PruebaHaruContext(DbContextOptions<PruebaHaruContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S78SCGN;Database=PruebaHaru;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompras).HasName("PK__Compras__3F5151B67BEFA9F5");

            entity.HasOne(d => d.IdPersonasNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdPersonas)
                .HasConstraintName("FK_IdPersonas");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProductos)
                .HasConstraintName("FK_IdProductos");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersonas).HasName("PK__Personas__05A9201295577E9B");

            entity.Property(e => e.CedulaPersona)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DireccionPersona)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailPersona)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TelefonoPersona)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PK__Producto__718C7D07CD67B2BA");

            entity.Property(e => e.CodProducto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreProductos)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

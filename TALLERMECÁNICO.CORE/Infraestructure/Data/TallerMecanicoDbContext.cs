using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TALLERMECÁNICO.CORE.Infraestructure.Data;

public partial class TallerMecanicoDbContext : DbContext
{
    public TallerMecanicoDbContext()
    {
    }

    public TallerMecanicoDbContext(DbContextOptions<TallerMecanicoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<OrdenServicio> OrdenServicio { get; set; }

    public virtual DbSet<TipoServicio> TipoServicio { get; set; }

    public virtual DbSet<Vehiculo> Vehiculo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AO2300928;Database=TallerMecanicoDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Correo).HasMaxLength(150);
            entity.Property(e => e.Materno).HasMaxLength(100);
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Paterno).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<OrdenServicio>(entity =>
        {
            entity.Property(e => e.CostoEstimado).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

            entity.HasOne(d => d.TipoServicio).WithMany(p => p.OrdenServicio)
                .HasForeignKey(d => d.TipoServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenServicio_TipoServicio");

            entity.HasOne(d => d.Vehiculo).WithMany(p => p.OrdenServicio)
                .HasForeignKey(d => d.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenServicio_Vehiculo");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PrecioBase).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.Property(e => e.Marca).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Placa).HasMaxLength(20);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Vehiculo)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehiculo_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

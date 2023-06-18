using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TallerModeloBasadoDb.Db.Entities;

public partial class BdProyectoContext : DbContext
{
    public BdProyectoContext()
    {
    }

    public BdProyectoContext(DbContextOptions<BdProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VentaCabecera> VentaCabeceras { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    public virtual DbSet<VideoJuego> VideoJuegos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BdProyecto;Trusted_Connection=True; MultipleActiveResultSets = True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_cliente");

            entity.ToTable("Cliente");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VentaCabecera>(entity =>
        {
            entity.ToTable("VentaCabecera");

            entity.Property(e => e.Fecha).HasColumnType("date");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VentaCabeceras)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__VentaCabe__IdCli__4BAC3F29");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.VentaCabeceras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__VentaCabe__IdUsu__4CA06362");
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.ToTable("VentaDetalle");

            entity.HasOne(d => d.IdVentaCabeceraNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdVentaCabecera)
                .HasConstraintName("FK__VentaDeta__IdVen__5535A963");

            entity.HasOne(d => d.IdVideoJuegoNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdVideoJuego)
                .HasConstraintName("FK__VentaDeta__IdVid__59063A47");
        });

        modelBuilder.Entity<VideoJuego>(entity =>
        {
            entity.ToTable("VideoJuego");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.Proveedor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class TiendaGeekContext : DbContext
{
    public TiendaGeekContext()
    {
    }

    public TiendaGeekContext(DbContextOptions<TiendaGeekContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<HistorialPedido> HistorialPedidos { get; set; }

    public virtual DbSet<ImagenProducto> ImagenProductos { get; set; }

    public virtual DbSet<Orden> Ordens { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=KENG;Database=TiendaGeek;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CodigoCarrito).HasName("PK__Carrito__20E75EFA432AFAF3");

            entity.ToTable("Carrito");

            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK__Carrito__CodigoP__4222D4EF");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.CodigoUsuario)
                .HasConstraintName("FK__Carrito__CodigoU__412EB0B6");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__Categori__3CEE2F4C43D6803C");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialPedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Historia__3213E83FFF09D83E");

            entity.ToTable("Historial_Pedidos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaDeCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_de_creacion");
            entity.Property(e => e.IdOrden).HasColumnName("id_orden");
        });

        modelBuilder.Entity<ImagenProducto>(entity =>
        {
            entity.HasKey(e => e.CodigoImagen).HasName("PK__ImagenPr__B3306E291A1321BD");

            entity.ToTable("ImagenProducto");

            entity.Property(e => e.RutaImagen)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.ImagenProductos)
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK__ImagenPro__Codig__3E52440B");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.CodigoOrden).HasName("PK__Orden__1B9107A5AE976C29");

            entity.ToTable("Orden");

            entity.HasOne(d => d.CodigoCarritoNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.CodigoCarrito)
                .HasConstraintName("FK__Orden__CodigoCar__45F365D3");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.CodigoUsuario)
                .HasConstraintName("FK__Orden__CodigoUsu__44FF419A");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__785B009EE00033A2");

            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoCategoria)
                .HasConstraintName("FK__Producto__Codigo__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__Usuario__F0C18F5893699BB7");

            entity.ToTable("Usuario");

            entity.Property(e => e.Contrasena)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PrimerApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SegundoApellido)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

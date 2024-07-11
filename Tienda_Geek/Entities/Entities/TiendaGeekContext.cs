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
        => optionsBuilder.UseSqlServer("Server=.;Database=TiendaGeek;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CodigoCarrito).HasName("PK__Carrito__20E75EFAA40CE134");

            entity.ToTable("Carrito");

            entity.Property(e => e.CodigoCarrito).ValueGeneratedNever();
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK__Carrito__CodigoP__2F10007B");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.CodigoUsuario)
                .HasConstraintName("FK__Carrito__CodigoU__2E1BDC42");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__Categori__3CEE2F4C70464530");

            entity.Property(e => e.CodigoCategoria).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialPedido>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Historia__3213E83F211A7CFE");

            entity.ToTable("Historial_Pedidos");

            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.id_orden).HasColumnName("id_orden");
        });

        modelBuilder.Entity<ImagenProducto>(entity =>
        {
            entity.HasKey(e => e.CodigoImagen).HasName("PK__ImagenPr__B3306E2909968200");

            entity.ToTable("ImagenProducto");

            entity.Property(e => e.CodigoImagen).ValueGeneratedNever();
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.ImagenProductos)
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK__ImagenPro__Codig__2B3F6F97");
        });

        modelBuilder.Entity<Orden>(entity =>
        {
            entity.HasKey(e => e.CodigoOrden).HasName("PK__Orden__1B9107A537059108");

            entity.ToTable("Orden");

            entity.Property(e => e.CodigoOrden).ValueGeneratedNever();

            entity.HasOne(d => d.CodigoCarritoNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.CodigoCarrito)
                .HasConstraintName("FK__Orden__CodigoCar__32E0915F");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Ordens)
                .HasForeignKey(d => d.CodigoUsuario)
                .HasConstraintName("FK__Orden__CodigoUsu__31EC6D26");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__785B009EB49CD1E4");

            entity.ToTable("Producto");

            entity.Property(e => e.CodigoProducto).ValueGeneratedNever();
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
                .HasConstraintName("FK__Producto__Codigo__286302EC");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__Usuario__F0C18F58F840E22C");

            entity.ToTable("Usuario");

            entity.Property(e => e.CodigoUsuario).ValueGeneratedNever();
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

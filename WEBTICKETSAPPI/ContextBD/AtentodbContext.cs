using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WEBTICKETSAPPI.ContextBD;

public partial class AtentodbContext : DbContext
{
    public AtentodbContext()
    {
    }

    public AtentodbContext(DbContextOptions<AtentodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atencion> Atencions { get; set; }

    public virtual DbSet<Averium> Averia { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Tiposolucion> Tiposolucions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.NIdAtencion).HasName("PRIMARY");

            entity.ToTable("atencion");

            entity.HasIndex(e => e.OAveria, "oAveria");

            entity.HasIndex(e => e.OTipoSol, "oTipoSol");

            entity.Property(e => e.NIdAtencion).HasColumnName("nIdAtencion");
            entity.Property(e => e.BSolEnLinea).HasColumnName("bSolEnLinea");
            entity.Property(e => e.OAveria).HasColumnName("oAveria");
            entity.Property(e => e.OTipoSol).HasColumnName("oTipoSol");

            entity.HasOne(d => d.OAveriaNavigation).WithMany(p => p.Atencions)
                .HasForeignKey(d => d.OAveria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("atencion_ibfk_1");

            entity.HasOne(d => d.OTipoSolNavigation).WithMany(p => p.Atencions)
                .HasForeignKey(d => d.OTipoSol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("atencion_ibfk_2");
        });

        modelBuilder.Entity<Averium>(entity =>
        {
            entity.HasKey(e => e.NIdAveria).HasName("PRIMARY");

            entity.ToTable("averia");

            entity.HasIndex(e => e.OCliente, "oCliente");

            entity.HasIndex(e => e.OProducto, "oProducto");

            entity.HasIndex(e => e.OUsuario, "oUsuario");

            entity.HasIndex(e => e.SCorreo, "sCorreo").IsUnique();

            entity.Property(e => e.NIdAveria).HasColumnName("nIdAveria");
            entity.Property(e => e.DRangoAtencion).HasColumnName("dRangoAtencion");
            entity.Property(e => e.OCliente).HasColumnName("oCliente");
            entity.Property(e => e.OProducto).HasColumnName("oProducto");
            entity.Property(e => e.OUsuario).HasColumnName("oUsuario");
            entity.Property(e => e.SCodOperacion)
                .HasMaxLength(10)
                .HasColumnName("sCodOperacion");
            entity.Property(e => e.SContacto)
                .HasMaxLength(50)
                .HasColumnName("sContacto");
            entity.Property(e => e.SCorreo)
                .HasMaxLength(50)
                .HasColumnName("sCorreo");
            entity.Property(e => e.SReferencia)
                .HasMaxLength(50)
                .HasColumnName("sReferencia");
            entity.Property(e => e.STelefono)
                .HasMaxLength(9)
                .HasColumnName("sTelefono");

            entity.HasOne(d => d.OClienteNavigation).WithMany(p => p.Averia)
                .HasForeignKey(d => d.OCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("averia_ibfk_1");

            entity.HasOne(d => d.OProductoNavigation).WithMany(p => p.Averia)
                .HasForeignKey(d => d.OProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("averia_ibfk_2");

            entity.HasOne(d => d.OUsuarioNavigation).WithMany(p => p.Averia)
                .HasForeignKey(d => d.OUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("averia_ibfk_3");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.NIdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.OIdUsuario, "oIdUsuario");

            entity.HasIndex(e => e.SCorreo, "sCorreo").IsUnique();

            entity.Property(e => e.NIdCliente).HasColumnName("nIdCliente");
            entity.Property(e => e.OIdUsuario).HasColumnName("oIdUsuario");
            entity.Property(e => e.SApellMaterno)
                .HasMaxLength(20)
                .HasColumnName("sApellMaterno");
            entity.Property(e => e.SApellPaterno)
                .HasMaxLength(20)
                .HasColumnName("sApellPaterno");
            entity.Property(e => e.SCorreo)
                .HasMaxLength(50)
                .HasColumnName("sCorreo");
            entity.Property(e => e.SDireccion)
                .HasMaxLength(60)
                .HasColumnName("sDireccion");
            entity.Property(e => e.SNombres)
                .HasMaxLength(20)
                .HasColumnName("sNombres");
            entity.Property(e => e.SNumDoc)
                .HasMaxLength(11)
                .HasColumnName("sNumDoc");
            entity.Property(e => e.STelefono)
                .HasMaxLength(9)
                .HasColumnName("sTelefono");
            entity.Property(e => e.STipoDoc)
                .HasMaxLength(10)
                .HasColumnName("sTipoDoc");

            entity.HasOne(d => d.OIdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.OIdUsuario)
                .HasConstraintName("cliente_ibfk_1");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.NIdMenu).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.HasIndex(e => e.ORol, "oRol");

            entity.Property(e => e.NIdMenu).HasColumnName("nId_Menu");
            entity.Property(e => e.ORol).HasColumnName("oRol");
            entity.Property(e => e.SAcceso)
                .HasMaxLength(20)
                .HasColumnName("sAcceso");
            entity.Property(e => e.SNombre)
                .HasMaxLength(20)
                .HasColumnName("sNombre");

            entity.HasOne(d => d.ORolNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.ORol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("menu_ibfk_1");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.NId).HasName("PRIMARY");

            entity.ToTable("menu_rol");

            entity.HasIndex(e => e.OIdRol, "oIdRol");

            entity.HasIndex(e => e.OIdMenu, "oId_Menu");

            entity.Property(e => e.NId).HasColumnName("nId");
            entity.Property(e => e.OIdMenu).HasColumnName("oId_Menu");
            entity.Property(e => e.OIdRol).HasColumnName("oIdRol");

            entity.HasOne(d => d.OIdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.OIdMenu)
                .HasConstraintName("menu_rol_ibfk_1");

            entity.HasOne(d => d.OIdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.OIdRol)
                .HasConstraintName("menu_rol_ibfk_2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.NIdProducto).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.Property(e => e.NIdProducto).HasColumnName("nIdProducto");
            entity.Property(e => e.SDescripcion)
                .HasMaxLength(20)
                .HasColumnName("sDescripcion");
            entity.Property(e => e.SEstado)
                .HasMaxLength(10)
                .HasColumnName("sEstado");
            entity.Property(e => e.SNombre)
                .HasMaxLength(20)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.NIdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.Property(e => e.NIdRol).HasColumnName("nIdRol");
            entity.Property(e => e.SDescripcionRol)
                .HasMaxLength(20)
                .HasColumnName("sDescripcionRol");
            entity.Property(e => e.SNombreRol)
                .HasMaxLength(20)
                .HasColumnName("sNombreRol");
        });

        modelBuilder.Entity<Tiposolucion>(entity =>
        {
            entity.HasKey(e => e.NIdTipoSol).HasName("PRIMARY");

            entity.ToTable("tiposolucion");

            entity.Property(e => e.NIdTipoSol).HasColumnName("nIdTipoSol");
            entity.Property(e => e.SDescripcion)
                .HasMaxLength(200)
                .HasColumnName("sDescripcion");
            entity.Property(e => e.SNombre)
                .HasMaxLength(50)
                .HasColumnName("sNombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.NIdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.ORol, "oRol");

            entity.HasIndex(e => e.SUsername, "sUsername").IsUnique();

            entity.Property(e => e.NIdUsuario).HasColumnName("nIdUsuario");
            entity.Property(e => e.NEstado).HasColumnName("nEstado");
            entity.Property(e => e.ORol).HasColumnName("oRol");
            entity.Property(e => e.SApellMaterno)
                .HasMaxLength(20)
                .HasColumnName("sApellMaterno");
            entity.Property(e => e.SApellPaterno)
                .HasMaxLength(20)
                .HasColumnName("sApellPaterno");
            entity.Property(e => e.SNombres)
                .HasMaxLength(20)
                .HasColumnName("sNombres");
            entity.Property(e => e.SPassword)
                .HasMaxLength(20)
                .HasColumnName("sPassword");
            entity.Property(e => e.SUsername)
                .HasMaxLength(20)
                .HasColumnName("sUsername");

            entity.HasOne(d => d.ORolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.ORol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

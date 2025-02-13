using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CursoAPI.Models;

public partial class BdcursoContext : DbContext
{
    public BdcursoContext()
    {
    }

    public BdcursoContext(DbContextOptions<BdcursoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriaCurso> CategoriaCursos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<SeccionCurso> SeccionCursos { get; set; }

    public virtual DbSet<VideosSeccion> VideosSeccions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=192.168.3.81;Database=BDCurso;integrated security=True;MultipleActiveResultSets=True; Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriaCurso>(entity =>
        {
            entity.HasKey(e => e.Iidcategoriacurso).HasName("PK_TipoCurso");

            entity.ToTable("CategoriaCurso");

            entity.Property(e => e.Iidcategoriacurso).HasColumnName("IIDCATEGORIACURSO");
            entity.Property(e => e.Habilitado).HasColumnName("HABILITADO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.Iidcurso);

            entity.ToTable("Curso");

            entity.Property(e => e.Iidcurso).HasColumnName("IIDCURSO");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Cupon)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CUPON");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Iidcategoriacurso).HasColumnName("IIDCATEGORIACURSO");
            entity.Property(e => e.Imagen)
                .IsUnicode(false)
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("PRECIO");

            entity.HasOne(d => d.IidcategoriacursoNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.Iidcategoriacurso)
                .HasConstraintName("FK_Curso_CategoriaCurso");
        });

        modelBuilder.Entity<SeccionCurso>(entity =>
        {
            entity.HasKey(e => e.Iidseccion);

            entity.ToTable("SeccionCurso");

            entity.Property(e => e.Iidseccion).HasColumnName("IIDSECCION");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Descripcionseccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCIONSECCION");
            entity.Property(e => e.Iidcurso).HasColumnName("IIDCURSO");
            entity.Property(e => e.Nombreseccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRESECCION");

            entity.HasOne(d => d.IidcursoNavigation).WithMany(p => p.SeccionCursos)
                .HasForeignKey(d => d.Iidcurso)
                .HasConstraintName("FK_SeccionCurso_Curso");
        });

        modelBuilder.Entity<VideosSeccion>(entity =>
        {
            entity.HasKey(e => e.Iidvideos).HasName("PK_VideosSeccions");

            entity.ToTable("VideosSeccion");

            entity.Property(e => e.Iidvideos).HasColumnName("IIDVIDEOS");
            entity.Property(e => e.Bhabilitado).HasColumnName("BHABILITADO");
            entity.Property(e => e.Enlace)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ENLACE");
            entity.Property(e => e.Iidseccion).HasColumnName("IIDSECCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Video)
                .IsUnicode(false)
                .HasColumnName("VIDEO");

            entity.HasOne(d => d.IidseccionNavigation).WithMany(p => p.VideosSeccions)
                .HasForeignKey(d => d.Iidseccion)
                .HasConstraintName("FK_VideosSeccion_SeccionCurso");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

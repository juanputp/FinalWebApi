using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinalWebApi.Models
{
    public partial class RestdotnetContext : DbContext
    {
        public RestdotnetContext()
        {
        }

        public RestdotnetContext(DbContextOptions<RestdotnetContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TemperatureRegs> TemperatureRegs { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemperatureRegs>(entity =>
            {
                entity.ToTable("TEMP_REG");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("fecha_registro");

                entity.Property(e => e.HumedadRelativa).HasColumnName("humedad_relativa");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("identificacion");

                entity.Property(e => e.Temperatura).HasColumnName("temperatura");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Contraseña).HasMaxLength(50);

                entity.Property(e => e.IdUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Perfil).HasMaxLength(50);

                entity.HasKey(e => e.IdUsuario).HasName("PK_USUARIOS");

                entity.HasKey(e => e.Email).HasName("PK_USUARIOS");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

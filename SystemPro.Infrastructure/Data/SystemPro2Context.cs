using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SystemPro.Core.Entities;

namespace SystemPro.Infrastructure.Data
{
    public partial class SystemPro2Context : DbContext
    {
        public SystemPro2Context()
        {
        }

        public SystemPro2Context(DbContextOptions<SystemPro2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuRol> MenuRol { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TypeIdentification> TypeIdentification { get; set; }
        public virtual DbSet<User> User { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>(entity =>
            {
                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Display)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.FatherId).HasColumnName("FatherID");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MenuRol>(entity =>
            {
                entity.Property(e => e.MenuRolId)
                    .HasColumnName("MenuRolID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.RolId).HasColumnName("RolID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuRol)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuRol_Menu");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.MenuRol)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuRol_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolId)
                    .HasColumnName("RolID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RolName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TypeIdentification>(entity =>
            {
                entity.Property(e => e.TypeIdentificationId)
                    .HasColumnName("TypeIdentificationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastChange).HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumberId).HasColumnName("NumberID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RolId)
                    .HasColumnName("RolID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeIdentificationId).HasColumnName("TypeIdentificationID");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Roles");

                entity.HasOne(d => d.TypeIdentification)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TypeIdentificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_TypeIdentification");
            });
        }
    }
}

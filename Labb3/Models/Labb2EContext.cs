using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Labb3.Models
{
    public partial class Labb2EContext : DbContext
    {
        public Labb2EContext()
        {
        }

        public Labb2EContext(DbContextOptions<Labb2EContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anställda> Anställda { get; set; }
        public virtual DbSet<Betyg> Betyg { get; set; }
        public virtual DbSet<Elev> Elev { get; set; }
        public virtual DbSet<ElevBetyg> ElevBetyg { get; set; }
        public virtual DbSet<Klass> Klass { get; set; }
        public virtual DbSet<Ämne> Ämne { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-6TSF82P; Initial Catalog = Labb2E; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anställda>(entity =>
            {
                entity.HasKey(e => e.AnställningsNummer);

                entity.Property(e => e.Befattning).HasMaxLength(50);

                entity.Property(e => e.EfterNamn).HasMaxLength(50);

                entity.Property(e => e.FörNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.Property(e => e.BetygId).ValueGeneratedNever();

                entity.Property(e => e.Betyg1)
                    .HasColumnName("Betyg")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.BetygetSatDatum).HasColumnType("date");

                entity.Property(e => e.BetygsättandeLärareId).HasColumnName("BetygsättandeLärareID");

                entity.HasOne(d => d.BetygsättandeLärare)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.BetygsättandeLärareId)
                    .HasConstraintName("FK_Betyg_Anställda");

                entity.HasOne(d => d.ÄmneNavigation)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.Ämne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Ämne");
            });

            modelBuilder.Entity<Elev>(entity =>
            {
                entity.Property(e => e.EfterNamn).HasMaxLength(50);

                entity.Property(e => e.FörNamn).HasMaxLength(50);

                entity.Property(e => e.Personnummer).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.KlassNavigation)
                    .WithMany(p => p.Elev)
                    .HasForeignKey(d => d.Klass)
                    .HasConstraintName("FK_Elev_Klass");
            });

            modelBuilder.Entity<ElevBetyg>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.Betyg)
                    .WithMany()
                    .HasForeignKey(d => d.BetygId)
                    .HasConstraintName("FK_ElevBetyg_Betyg");

                entity.HasOne(d => d.Elev)
                    .WithMany()
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK_ElevBetyg_Elev");
            });

            modelBuilder.Entity<Klass>(entity =>
            {
                entity.Property(e => e.KlassId).ValueGeneratedNever();

                entity.Property(e => e.KlassNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Ämne>(entity =>
            {
                entity.Property(e => e.ÄmneId)
                    .HasColumnName("ÄmneID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ÄmneNamn).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

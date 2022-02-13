using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolaDBProjekt.Models
{
    public partial class SkolaDbContext : DbContext
    {
        public SkolaDbContext()
        {
        }

        public SkolaDbContext(DbContextOptions<SkolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betyg> Betyg { get; set; }
        public virtual DbSet<BetygPoäng> BetygPoäng { get; set; }
        public virtual DbSet<Elev> Elev { get; set; }
        public virtual DbSet<ElevKurs> ElevKurs { get; set; }
        public virtual DbSet<Klass> Klass { get; set; }
        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<LärareKurs> LärareKurs { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-JCAKF9L;Initial Catalog = SkolaProjekt;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Betyg>(entity =>
            {
                entity.Property(e => e.BetygId).ValueGeneratedNever();

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.FkkursId).HasColumnName("FKKursId");

                entity.Property(e => e.FkpersonalId).HasColumnName("FKPersonalId");

                entity.Property(e => e.Fkpersonnummer)
                    .IsRequired()
                    .HasColumnName("FKPersonnummer")
                    .HasMaxLength(13);

                entity.Property(e => e.SattBetyg).HasMaxLength(3);

                entity.HasOne(d => d.Fkkurs)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FkkursId)
                    .HasConstraintName("FK_Betyg_Kurs");

                entity.HasOne(d => d.Fkpersonal)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.FkpersonalId)
                    .HasConstraintName("FK_Betyg_Personal");

                entity.HasOne(d => d.FkpersonnummerNavigation)
                    .WithMany(p => p.Betyg)
                    .HasForeignKey(d => d.Fkpersonnummer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betyg_Elev");

                entity.HasOne(d => d.SattBetygNavigation)
                    .WithMany(p => p.BetygNavigation)
                    .HasForeignKey(d => d.SattBetyg)
                    .HasConstraintName("FK_Betyg_BetygPoäng");
            });

            modelBuilder.Entity<BetygPoäng>(entity =>
            {
                entity.HasKey(e => e.Betyg);

                entity.Property(e => e.Betyg).HasMaxLength(3);
            });

            modelBuilder.Entity<Elev>(entity =>
            {
                entity.HasKey(e => e.Personnummer);

                entity.Property(e => e.Personnummer).HasMaxLength(13);

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.FkklassId).HasColumnName("FKKlassId");

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Kön).HasMaxLength(50);

                entity.HasOne(d => d.Fkklass)
                    .WithMany(p => p.Elev)
                    .HasForeignKey(d => d.FkklassId)
                    .HasConstraintName("FK_Elev_Klass");
            });

            modelBuilder.Entity<ElevKurs>(entity =>
            {
                entity.Property(e => e.ElevKursId).ValueGeneratedNever();

                entity.Property(e => e.FkkursId).HasColumnName("FKKursId");

                entity.Property(e => e.Fkpersonnummer)
                    .HasColumnName("FKPersonnummer")
                    .HasMaxLength(13);

                entity.HasOne(d => d.Fkkurs)
                    .WithMany(p => p.ElevKurs)
                    .HasForeignKey(d => d.FkkursId)
                    .HasConstraintName("FK_ElevKurs_Kurs");

                entity.HasOne(d => d.FkpersonnummerNavigation)
                    .WithMany(p => p.ElevKurs)
                    .HasForeignKey(d => d.Fkpersonnummer)
                    .HasConstraintName("FK_ElevKurs_Elev");
            });

            modelBuilder.Entity<Klass>(entity =>
            {
                entity.Property(e => e.KlassId).ValueGeneratedNever();

                entity.Property(e => e.KlassNamn).HasMaxLength(50);
            });

            modelBuilder.Entity<Kurs>(entity =>
            {
                entity.Property(e => e.KursId).ValueGeneratedNever();

                entity.Property(e => e.Slutdatum).HasColumnType("date");

                entity.Property(e => e.Startdatum).HasColumnType("date");

                entity.Property(e => e.Ämne).HasMaxLength(50);
            });

            modelBuilder.Entity<LärareKurs>(entity =>
            {
                entity.Property(e => e.LärareKursId).ValueGeneratedNever();

                entity.Property(e => e.FkkursId).HasColumnName("FKKursId");

                entity.Property(e => e.FkpersonalId).HasColumnName("FKPersonalId");

                entity.HasOne(d => d.Fkkurs)
                    .WithMany(p => p.LärareKurs)
                    .HasForeignKey(d => d.FkkursId)
                    .HasConstraintName("FK_LärareKurs_Kurs1");

                entity.HasOne(d => d.Fkpersonal)
                    .WithMany(p => p.LärareKurs)
                    .HasForeignKey(d => d.FkpersonalId)
                    .HasConstraintName("FK_LärareKurs_Personal");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.Property(e => e.PersonalId).ValueGeneratedNever();

                entity.Property(e => e.Befattning).HasMaxLength(50);

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Månadslön).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

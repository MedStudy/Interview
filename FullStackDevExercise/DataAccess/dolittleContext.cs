using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FullStackDevExercise.DataAccess
{
    public partial class dolittleContext : DbContext
    {
        public dolittleContext()
        {
        }

        public dolittleContext(DbContextOptions<dolittleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointments> Appointments { get; set; }
        public virtual DbSet<Owners> Owners { get; set; }
        public virtual DbSet<Pets> Pets { get; set; }
        public virtual DbSet<Vets> Vets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=C:\\Development\\Experiments\\Interview\\FullStackDevExercise\\dolittle.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>(entity =>
            {
                entity.ToTable("appointments");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.OwnerId)
                    .HasColumnName("owner_id")
                    .HasColumnType("INT");

                entity.Property(e => e.PetId)
                    .HasColumnName("pet_id")
                    .HasColumnType("INT");

                entity.Property(e => e.ScheduledDate).HasColumnName("scheduled_date");

                entity.Property(e => e.VetId)
                    .HasColumnName("vet_id")
                    .HasColumnType("INT");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.OwnerId);

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PetId);

                entity.HasOne(d => d.Vet)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.VetId);
            });

            modelBuilder.Entity<Owners>(entity =>
            {
                entity.ToTable("owners");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<Pets>(entity =>
            {
                entity.ToTable("pets");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .HasColumnName("age")
                    .HasColumnType("INT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.OwnerId)
                    .HasColumnName("owner_id")
                    .HasColumnType("INT");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("VARCHAR(50)");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.OwnerId);
            });

            modelBuilder.Entity<Vets>(entity =>
            {
                entity.ToTable("vets");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(250)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

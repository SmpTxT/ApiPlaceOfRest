using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIPlaceOfRestProject
{
    public partial class APIPlaceOfRestContext : DbContext
    {
        public APIPlaceOfRestContext()
        {
        }

        public APIPlaceOfRestContext(DbContextOptions<APIPlaceOfRestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Coordinate> Coordinates { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventLink> EventLinks { get; set; }
        public virtual DbSet<PictureLink> PictureLinks { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<Underground> Undergrounds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:apiplaceofrest.database.windows.net,1433;Initial Catalog=APIPlaceOfRest;Persist Security Info=False;User ID=andry;Password=An19952012;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.Idbuilding);

                entity.ToTable("Building");

                entity.Property(e => e.Idbuilding).HasColumnName("IDBuilding");

                entity.Property(e => e.Idcoordinate).HasColumnName("IDCoordinate");

                entity.Property(e => e.Idstreet).HasColumnName("IDStreet");

                entity.HasOne(d => d.IdcoordinateNavigation)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.Idcoordinate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Building__IDCoor__73BA3083");

                entity.HasOne(d => d.IdstreetNavigation)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.Idstreet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Building");
            });

            modelBuilder.Entity<Coordinate>(entity =>
            {
                entity.HasKey(e => e.Idcoordinate);

                entity.ToTable("Coordinate");

                entity.Property(e => e.Idcoordinate).HasColumnName("IDCoordinate");

                entity.Property(e => e.Latitude).IsRequired();

                entity.Property(e => e.Longitude).IsRequired();
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Event");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Idevent)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDEvent");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<EventLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EventLink");

                entity.Property(e => e.Idevent)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDEvent");

                entity.Property(e => e.Link).HasColumnName("link");
            });

            modelBuilder.Entity<PictureLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PictureLink");

                entity.Property(e => e.Idpicture)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPicture");

                entity.Property(e => e.Link).HasColumnName("link");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasKey(e => e.Idstreet);

                entity.ToTable("Street");

                entity.Property(e => e.Idstreet).HasColumnName("IDStreet");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Theme");

                entity.Property(e => e.Idtheme)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDTheme");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Underground>(entity =>
            {
                entity.HasKey(e => e.Idunderground);

                entity.ToTable("Underground");

                entity.Property(e => e.Idunderground).HasColumnName("IDUnderground");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

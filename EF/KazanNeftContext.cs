using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KazanNeftApi.EF
{
    public partial class KazanNeftContext : DbContext
    {
        public KazanNeftContext()
        {
        }

        public KazanNeftContext(DbContextOptions<KazanNeftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetGroups> AssetGroups { get; set; }
        public virtual DbSet<AssetPhotos> AssetPhotos { get; set; }
        public virtual DbSet<AssetTransferLogs> AssetTransferLogs { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<DepartmentLocations> DepartmentLocations { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("Server=192.168.88.234;Database=KazanNeft;user=sa;password=Cortik228");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetGroups>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AssetPhotos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AssetPhoto).IsRequired();

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetPhotos)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetPhotos_Assets");
            });

            modelBuilder.Entity<AssetTransferLogs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.FromAssetSn)
                    .IsRequired()
                    .HasColumnName("FromAssetSN")
                    .HasMaxLength(20);

                entity.Property(e => e.FromDepartmentLocationId).HasColumnName("FromDepartmentLocationID");

                entity.Property(e => e.ToAssetSn)
                    .IsRequired()
                    .HasColumnName("ToAssetSN")
                    .HasMaxLength(20);

                entity.Property(e => e.ToDepartmentLocationId).HasColumnName("ToDepartmentLocationID");

                entity.Property(e => e.TransferDate).HasColumnType("date");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.AssetTransferLogs)
                    .HasForeignKey(d => d.AssetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetTransfers_Assets");

                entity.HasOne(d => d.FromDepartmentLocation)
                    .WithMany(p => p.AssetTransferLogsFromDepartmentLocation)
                    .HasForeignKey(d => d.FromDepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetTransferLogs_DepartmentLocations");

                entity.HasOne(d => d.ToDepartmentLocation)
                    .WithMany(p => p.AssetTransferLogsToDepartmentLocation)
                    .HasForeignKey(d => d.ToDepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssetTransferLogs_DepartmentLocations1");
            });

            modelBuilder.Entity<Assets>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetGroupId).HasColumnName("AssetGroupID");

                entity.Property(e => e.AssetName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.AssetSn)
                    .IsRequired()
                    .HasColumnName("AssetSN")
                    .HasMaxLength(20);

                entity.Property(e => e.DepartmentLocationId).HasColumnName("DepartmentLocationID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.WarrantyDate).HasColumnType("date");

                entity.HasOne(d => d.AssetGroup)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.AssetGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_AssetGroups");

                entity.HasOne(d => d.DepartmentLocation)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.DepartmentLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_DepartmentLocations");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assets_Employees");
            });

            modelBuilder.Entity<DepartmentLocations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentLocations)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentLocations_Departments");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.DepartmentLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentLocations_Locations");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using CityTransport.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CityTransport.Infrastructure.Data
{
    public partial class RatBVTransportContext : DbContext
    {
        public RatBVTransportContext()
        {
        }

        public RatBVTransportContext(DbContextOptions<RatBVTransportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<BusStation> BusStations { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<MetropolitanArea> MetropolitanAreas { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<FavoriteBusRoute> Favorites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=Server=ratbvsql.crqnj8vaobcj.eu-central-1.rds.amazonaws.com;Database=RatBVTransport;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.AreaName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Area__CityID__6E01572D");
            });

          

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.HasKey(e => e.BusId)
                    .HasName("PK__Bus__6A0F609575E632E3");

                entity.ToTable("Bus");

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.BusName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusStation>(entity =>
            {
                entity.HasKey(e => e.StationId)
                    .HasName("PK__BusStati__E0D8A6DDC8727232");

                entity.ToTable("BusStation");

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.StationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.BusStations)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK__BusStatio__AreaI__70DDC3D8");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MetropolitanAreaId).HasColumnName("MetropolitanAreaID");

                entity.HasOne(d => d.MetropolitanArea)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.MetropolitanAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__Metropolit__6B24EA82");
            });

            modelBuilder.Entity<MetropolitanArea>(entity =>
            {
                entity.ToTable("MetropolitanArea");

                entity.Property(e => e.MetropolitanAreaId).HasColumnName("MetropolitanAreaID");

                entity.Property(e => e.MetropolitanAreaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.ArrivalTime)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BusId).HasColumnName("BusID");

                entity.Property(e => e.DayOfWeek)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StationId).HasColumnName("StationID");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.BusId)
                    .HasConstraintName("FK__Schedule__BusID__75A278F5");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK__Schedule__Statio__76969D2E");
            });

            modelBuilder.Entity<FavoriteBusRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId).HasName("PK__FavoriteBusRoute__E0D8A6DDC8427532");

                entity.ToTable("FavoriteBusRoute");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.BusName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StationFrom)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StationTo)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

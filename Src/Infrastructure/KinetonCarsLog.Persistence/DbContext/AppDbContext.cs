using KinetonCarsLog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace KinetonCarsLog.Persistence.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        
        public virtual DbSet<CarColor> CarColors { get; set; }
        
        public virtual DbSet<CarType> CarTypes { get; set; }
        
        public virtual DbSet<Engine> Engines { get; set; }
        
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        
        public virtual DbSet<Report> Reports { get; set; }
        
        public virtual DbSet<ReportsCar> ReportsCars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=KinetonCarsLog;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarTypeId).HasColumnName("car_type_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.EngineId).HasColumnName("engine_id");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("model");

                entity.Property(e => e.SeatCount).HasColumnName("seat_count");

                entity.HasOne(d => d.CarType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cars__car_type_i__37A5467C");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cars__color_id__38996AB5");

                entity.HasOne(d => d.Engine)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.EngineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cars__engine_id__398D8EEE");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cars__manufactur__36B12243");
            });

            modelBuilder.Entity<CarColor>(entity =>
            {
                entity.HasIndex(e => e.ColorName, "UQ__CarColor__2F423AB8DCC33815")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("color_name");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.HasIndex(e => e.Type, "UQ__CarTypes__E3F85248F85BE12C")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Engine>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.FuelConsumption).HasColumnName("fuel_consumption");

                entity.Property(e => e.FuelTypeId).HasColumnName("fuel_type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Rpm).HasColumnName("rpm");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Engines)
                    .HasForeignKey(d => d.FuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Engines__fuel_ty__32E0915F");
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasIndex(e => e.Type, "UQ__FuelType__E3F85248E66C696B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Manufact__72E12F1BEDA227C6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("country");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedUtc)
                    .HasColumnType("date")
                    .HasColumnName("created_UTC");
            });

            modelBuilder.Entity<ReportsCar>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.CarId })
                    .HasName("PK__Reports___5352DC836E50B92A");

                entity.ToTable("Reports_Cars");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CountOfCars).HasColumnName("count_of_cars");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.ReportsCars)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reports_C__car_i__403A8C7D");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportsCars)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reports_C__repor__3F466844");
            });

        }
    }
}

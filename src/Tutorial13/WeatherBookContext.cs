using Microsoft.EntityFrameworkCore;
using Tutorial13.Entities;

namespace Tutorial13;

public partial class WeatherBookContext : DbContext
{
    public WeatherBookContext()
    {
    }

    public WeatherBookContext(DbContextOptions<WeatherBookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<WeatherRecord> WeatherRecords { get; set; }

    public virtual DbSet<WeatherType> WeatherTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("City_pk");

            entity.ToTable("City");

            entity.Property(e => e.Latitude).HasColumnType("decimal(8, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Country_pk");

            entity.ToTable("Country");

            entity.HasIndex(e => e.Name, "Country_name_uk").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WeatherRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WeatherRecord_pk");

            entity.ToTable("WeatherRecord");

            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.WeatherRecords)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WeatherRecord_City");

            entity.HasOne(d => d.WeatherType).WithMany(p => p.WeatherRecords)
                .HasForeignKey(d => d.WeatherTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WeatherRecord_WeatherType");
        });

        modelBuilder.Entity<WeatherType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WeatherType_pk");

            entity.ToTable("WeatherType");

            entity.HasIndex(e => e.Name, "WeatherType_name_uk").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

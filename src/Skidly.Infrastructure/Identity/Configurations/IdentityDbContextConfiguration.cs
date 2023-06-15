using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skidly.Domain.Aggregates;
using Skidly.Domain.ValueObjects.ApplicationUser;

namespace Skidly.Infrastructure.Identity.Configurations;

public class IdentityDbContextConfiguration 
    : IEntityTypeConfiguration<ApplicationUser>,
      IEntityTypeConfiguration<Role>,
      IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var fullnameConverter =
            new ValueConverter<Fullname?, string?>(
                fullname => fullname != null ? fullname.ToString() : null,
                fullname => fullname != null ? new Fullname(fullname) : null);

        var dateOfBirthConverter =
            new ValueConverter<DateOfBirth?, DateTime?>(
                dateOfBirth => dateOfBirth != null ? dateOfBirth.Value : null,
                dateOfBirth => dateOfBirth != null ? new DateOfBirth(dateOfBirth.ToString()!) : null);

        var countryConverter =
            new ValueConverter<Country?, string?>(
                country => country != null ? country.Code : null,
                country => country != null ? new Country(country) : null);

        builder
            .Property(u => u.Fullname)
            .HasConversion(fullnameConverter)
            .HasColumnName("Fullname");

        builder
            .Property(u => u.DateOfBirth)
            .HasConversion(dateOfBirthConverter)
            .HasColumnName("DateOfBirth");

        builder
            .Property(u => u.Country)
            .HasConversion(countryConverter)
            .HasColumnName("Country");
        
            builder
                .ToTable("AspNetUsers");
    }

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable("AspNetRoles");
    }

    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder
            .ToTable("AspNetUserRoles");
    }
}
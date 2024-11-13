using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Infrastructure.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Name)
            .HasMaxLength(200);

        builder.Property(user => user.Birthday)
            .HasColumnType("date");

        builder.Property(user => user.Profession)
            .HasMaxLength(200);

        builder.Property(user => user.IdentityId)
            .HasMaxLength(200);

        builder.Property(user => user.Nationality)
            .HasMaxLength(200);

        builder.Property(user => user.PhoneNumber)
            .HasMaxLength(200);

        builder.Property(user => user.Email)
            .HasMaxLength(400);

        builder.Property(user => user.Salary);

        builder.HasIndex(user => user.Email).IsUnique();

        builder.HasIndex(user => user.IdentityId).IsUnique();
    }
}
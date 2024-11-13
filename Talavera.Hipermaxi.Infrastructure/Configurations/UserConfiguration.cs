using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Talavera.Hipermaxi.Domain.Users;

namespace Talavera.Hipermaxi.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.Profession).IsRequired();
        builder.Property(x => x.Nationality).IsRequired();
        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Salary).IsRequired();
    }
}
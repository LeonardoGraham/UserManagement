using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Users.Persistence;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.FirstName);
        
        builder.Property(u => u.LastName);
        
        builder.Property(u => u.Email);

        builder.Property(u => u.DateOfBirth);

        builder.Property(u => u.UserType)
            .HasConversion(
                userType => userType.Name,
                value => UserType.FromName(value, false));
    }
}
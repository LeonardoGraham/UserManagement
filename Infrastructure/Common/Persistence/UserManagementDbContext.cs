using System.Reflection;
using Application.Users.Common.Interfaces;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common.Persistence;

public class UserManagementDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; init; } = null!;
    public async Task CommitChangesAsync(CancellationToken cancellationToken)
    {
        await SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
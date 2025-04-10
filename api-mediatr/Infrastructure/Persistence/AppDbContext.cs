namespace ApiMediatr.Infrastructure.Persistence {
using Microsoft.EntityFrameworkCore;
using ApiMediatr.Core.Domain.Entities;
using ApiMediatr.Core.Domain.Entities;
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
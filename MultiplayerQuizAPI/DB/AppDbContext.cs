using Microsoft.EntityFrameworkCore;
using MultiplayerQuizAPI.models;

namespace MultiplayerQuizAPI.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}

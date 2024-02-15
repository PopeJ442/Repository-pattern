using Microsoft.EntityFrameworkCore;
using Seedingdata.Models;

namespace RepositoryPattern.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Player>Staging_Players { get; set; }   
    }
}

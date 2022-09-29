using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Entites;

namespace WebApplication1.DAL
{
    public class GameContext : DbContext
    {

        public DbSet<Menu> Menu { get; set; }
        public DbSet<FileContent> FileContent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=DBDemo;Trusted_Connection=True;");
        }
    }
}

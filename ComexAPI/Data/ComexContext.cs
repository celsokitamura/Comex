using ComexLibrary;
using Microsoft.EntityFrameworkCore;

namespace ComexAPI.Data
{
    public class ComexContext : DbContext
    {
        public ComexContext(DbContextOptions<ComexContext> opts) : base(opts)
        {

        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}

using APIMercador.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMercador.Context
{
    public class MercadorDbContext : DbContext
    {
        public MercadorDbContext(DbContextOptions<MercadorDbContext> options) : base (options)
        {

        }
        //---
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}

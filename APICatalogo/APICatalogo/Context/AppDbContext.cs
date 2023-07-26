using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextoptions<AppDbContext> options) : base(options) 
        {  }

        public Dbset<Categoria> Categorias { get; set; }
        public Dbset<Produto> Produtos { get; set; }
    }
}

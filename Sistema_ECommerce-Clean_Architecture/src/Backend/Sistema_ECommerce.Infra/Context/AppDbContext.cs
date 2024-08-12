using Microsoft.EntityFrameworkCore;
using Sistema_ECommerce.Domain.Entities;
using Sistema_ECommerce.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_ECommerce.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public virtual DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientesMap());
        }


        //retirar essa parte daqui depois de utilizar no mapeamento do banco de dados:

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LENILSONNOTE\SQLEXPRESS;Initial Catalog=ECommerceDB-DDD;Integrated Security=True;TrustServerCertificate=True;");
            }
        }
        
    }
}

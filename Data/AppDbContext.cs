using Microsoft.EntityFrameworkCore;
using SaleMasterApi.Models;

namespace SaleMasterApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        //public DbSet<FormaPagamento> FormasPagamento { get; set; }
    }
}
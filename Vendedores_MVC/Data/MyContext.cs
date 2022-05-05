using Microsoft.EntityFrameworkCore;
using Vendedores_MVC.Models;

namespace Vendedores_MVC.Data
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options): base(options){ }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<RegistroDeVenda> RegistroDeVendas { get; set; }
    }
}
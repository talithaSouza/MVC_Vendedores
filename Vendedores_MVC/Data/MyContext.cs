using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendedores_MVC.Models;

namespace Vendedores_MVC.Data
{
    public class MyContext : DbContext
    {
        public MyContext (DbContextOptions<MyContext> options): base(options){ }

        public DbSet<Departamento> Departamento { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendedores_MVC.Data;
using Vendedores_MVC.Models;

namespace Vendedores_MVC.Service
{
    public class DepartamentoService
    {
        private readonly MyContext _context;
        public DepartamentoService(MyContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> RetornarTodosAsync()
        {
            return await _context.Departamentos.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}

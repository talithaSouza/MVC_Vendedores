using System;
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

        public List<Departamento> RetornarTodos()
        {
            return _context.Departamentos.OrderBy(x => x.Nome).ToList();
        }
    }
}

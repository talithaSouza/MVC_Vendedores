using System.Collections.Generic;
using System.Linq;
using Vendedores_MVC.Data;
using Vendedores_MVC.Models;

namespace Vendedores_MVC.Service
{
    public class VendedorService
    {
        private readonly MyContext _context;

        public VendedorService(MyContext context)
        {
            _context = context;
        }

        public List<Vendedor> RetornarTodos()
        {
            return _context.Vendedores.ToList();
        }
    }
}

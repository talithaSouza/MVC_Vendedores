using Microsoft.EntityFrameworkCore;
using System;
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
            return _context.Vendedores
                   .Include(x => x.Departamento)
                   .ToList();
        }

        public Vendedor Cadastrar(Vendedor vendedor)
        {
            try
            {
                if (vendedor == null)
                    return null;

                _context.Add(vendedor);
                _context.SaveChanges();

                return vendedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

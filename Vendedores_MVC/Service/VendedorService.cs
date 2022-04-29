using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Vendedores_MVC.Data;
using Vendedores_MVC.Models;
using Vendedores_MVC.Service.Exceptions;

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

        public Vendedor RetornarPorId(int id)
        {
            return _context.Vendedores
                            .Include(x => x.Departamento).FirstOrDefault(x => x.Id == id);
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
                throw new Exception(ex.Message);
            }
        }



        public bool Deletar(int id)
        {
            try
            {
                var delete = this.RetornarPorId(id);
                if (delete == null)
                    return false;

                _context.Remove(delete);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Vendedor vendedor)
        {
            if (!_context.Vendedores.Any(x => x.Id == vendedor.Id))
                throw new NotFoundException("Id não encontrado");

            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}

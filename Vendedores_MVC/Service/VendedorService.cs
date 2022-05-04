using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Vendedor>> RetornarTodosAsync()
        {
            return await _context.Vendedores
                   .Include(x => x.Departamento)
                   .ToListAsync();
        }

        public async Task<Vendedor> RetornarPorIdAsync(int id)
        {
            return await _context.Vendedores
                            .Include(x => x.Departamento).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Vendedor> CadastrarAsync(Vendedor vendedor)
        {
            try
            {
                if (vendedor == null)
                    return null;

                _context.Add(vendedor);
               await _context.SaveChangesAsync();

                return vendedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var delete = await this.RetornarPorIdAsync(id);
                if (delete == null)
                    return false;

                _context.Remove(delete);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AtualizarAsync(Vendedor vendedor)
        {
            bool existe = await _context.Vendedores.AnyAsync(x => x.Id == vendedor.Id);
            if (!existe)
                throw new NotFoundException("Id não encontrado");

            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}

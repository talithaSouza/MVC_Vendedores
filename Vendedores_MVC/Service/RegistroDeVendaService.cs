using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendedores_MVC.Data;
using Vendedores_MVC.Models;

namespace Vendedores_MVC.Service
{
    public class RegistroDeVendaService
    {
        private readonly MyContext _context;
        public RegistroDeVendaService(MyContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVenda>> BuscarPorDataAsync(DateTime? dataInicial, DateTime? dataFinal)
        {
            var result = from obj in _context.RegistroDeVendas select obj;

            if (dataInicial.HasValue)
                result = result.Where(x => x.Data >= dataInicial);

            if (dataFinal.HasValue)
                result = result.Where(x => x.Data <= dataFinal);

            return await result
                   .Include(x => x.Vendedor)
                   .ThenInclude(x => x.Departamento)
                   .OrderBy(x => x.Data).ToListAsync();
        }
    }
}

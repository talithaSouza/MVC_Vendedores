using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;

namespace Vendedores_MVC.Models
{
    public class Departamento : BaseModel
    {
        public string Nome { get; set; }
        public ICollection<Vendedor> ListVendedores { get; set; } = new List<Vendedor>();

        public void Add(Vendedor vendedor)
        {
            ListVendedores.Add(vendedor);
        }

        public decimal TotalVendas(DateTime inicial, DateTime final)
        {
            return ListVendedores.Sum(x => x.TotalVendas(inicial, final));
        }
    }
}

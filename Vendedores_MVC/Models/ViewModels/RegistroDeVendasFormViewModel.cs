using System;
using System.Collections.Generic;
using System.Linq;
using Vendedores_MVC.Models.Enums;

namespace Vendedores_MVC.Models.ViewModels
{
    public class RegistroDeVendasFormViewModel
    {
        public List<Vendedor> Vendedores { get; set; }
        public RegistroDeVenda RegistroDeVenda { get; set; }
        public IEnumerable<VendaStatus> ListStatus { get; set; }
    }
}

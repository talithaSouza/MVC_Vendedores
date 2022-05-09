using System.Collections.Generic;

namespace Vendedores_MVC.Models.ViewModels
{
    public class RegistroDeVendasFormViewModel
    {
        public List<Vendedor> Vendedores { get; set; }
        public RegistroDeVenda RegistroDeVenda { get; set; }
    }
}

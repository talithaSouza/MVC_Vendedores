using System.Collections.Generic;

namespace Vendedores_MVC.Models.ViewModels
{
    public class IndexRegistroVendaViewModel
    {
        public List<Vendedor> Vendedores{ get; set; }
        public int IdVendedor { get; set; }
    }
}

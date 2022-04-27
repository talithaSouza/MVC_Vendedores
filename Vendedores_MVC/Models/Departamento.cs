using System.Collections.Generic;

namespace Vendedores_MVC.Models
{
    public class Departamento : BaseModel
    {
        public string Nome { get; set; }
        public ICollection<Vendedor> ListVendedores { get; set; } = new List<Vendedor>();
    }
}

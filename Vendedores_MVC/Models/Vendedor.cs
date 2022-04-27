using System;
using System.Collections.Generic;

namespace Vendedores_MVC.Models
{
    public class Vendedor : BaseModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public int SalarioBase { get; set; }

        public int FK_Departamento { get; set; }
        public Departamento Departamento { get; set; }

        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

    }
}

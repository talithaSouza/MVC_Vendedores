using System;
using Vendedores_MVC.Models.Enum;

namespace Vendedores_MVC.Models
{
    public class RegistroDeVendas : BaseModel
    {
        public DateTime Data { get; set; }
        public decimal Somatorio { get; set; }
        public VendaStatus Status { get; set; }

        public int FK_Vendedor { get; set; }
        public Vendedor Vendedor { get; set; }

         
    }
}

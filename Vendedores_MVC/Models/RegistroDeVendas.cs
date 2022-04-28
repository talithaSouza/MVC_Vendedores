using System;
using Vendedores_MVC.Models.Enum;

namespace Vendedores_MVC.Models
{
    public class RegistroDeVendas : BaseModel
    {
        public DateTime Data { get; set; }
        public decimal Somatorio { get; set; }
        public VendaStatus Status { get; set; }

        public Vendedor Vendedor { get; set; }

        public RegistroDeVendas()
        {

        }

        public RegistroDeVendas(DateTime data, decimal somatorio, VendaStatus status, Vendedor vendedor)
        {
            Data = data;
            Somatorio = somatorio;
            Status = status;
            Vendedor = vendedor;
        }
    }
}

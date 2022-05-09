using System;
using System.ComponentModel.DataAnnotations;
using Vendedores_MVC.Models.Enum;

namespace Vendedores_MVC.Models
{
    public class RegistroDeVenda : BaseModel
    {
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public decimal Somatorio { get; set; }
        public VendaStatus Status { get; set; }

        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVenda()
        {

        }

        public RegistroDeVenda(DateTime data, decimal somatorio, VendaStatus status, Vendedor vendedor)
        {
            Data = data;
            Somatorio = somatorio;
            Status = status;
            Vendedor = vendedor;
        }
    }
}

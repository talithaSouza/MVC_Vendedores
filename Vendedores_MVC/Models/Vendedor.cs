using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Vendedores_MVC.Models
{
    public class Vendedor : BaseModel
    {
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Formato Invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data de Aniversário é obrigatório")]
        [Display(Name ="Data de Aniversário")]
        [DataType(DataType.Date)]
        public DateTime DataAniversario { get; set; }

        [Required(ErrorMessage = "Salário é obrigatório")]
        [Range(100,50000, ErrorMessage ="Salario no minimo {1} e no máximo {2}")]
        [Display(Name ="Salário Base R$:")]
        public int SalarioBase { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public ICollection<RegistroDeVenda> Vendas { get; set; } = new List<RegistroDeVenda>();

        public Vendedor()
        {

        }

        public Vendedor(string nome, string email, DateTime dataAniversario, int salarioBase, Departamento departamento)
        {
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void Add(RegistroDeVenda venda)
        {
            Vendas.Add(venda);
        }

        public void Remove(RegistroDeVenda venda)
        {
            if (Vendas.Count() > 0)
                Vendas.Remove(venda);
        }

        public decimal TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(x => x.Data >= inicial && x.Data <= final).Sum(x => x.Somatorio);
        }
    }
}

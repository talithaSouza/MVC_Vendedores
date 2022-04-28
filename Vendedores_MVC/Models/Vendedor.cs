﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Vendedores_MVC.Models
{
    public class Vendedor : BaseModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataAniversario { get; set; }
        public int SalarioBase { get; set; }
        public Departamento Departamento { get; set; }

        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();

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

        public void Add(RegistroDeVendas venda)
        {
            Vendas.Add(venda);
        }

        public void Remove(RegistroDeVendas venda)
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

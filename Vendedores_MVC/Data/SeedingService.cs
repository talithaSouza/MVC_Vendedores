using System;
using System.Linq;
using Vendedores_MVC.Models;
using Vendedores_MVC.Models.Enum;

namespace Vendedores_MVC.Data
{
    public class SeedingService
    {
        private MyContext _context;

        public SeedingService(MyContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamentos.Any() || _context.Vendedores.Any() || _context.RegistroDeVendas.Any())
            {
                return; // DB has been seeded
            }

            Departamento d1 = new Departamento("Computadores");
            Departamento d2 = new Departamento("Eletronicos");
            Departamento d3 = new Departamento("Fashion");
            Departamento d4 = new Departamento("Livro");

            Vendedor s1 = new Vendedor("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000, d1);
            Vendedor s2 = new Vendedor("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500, d2);
            Vendedor s3 = new Vendedor("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200, d1);
            Vendedor s4 = new Vendedor("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000, d4);
            Vendedor s5 = new Vendedor("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000, d3);
            Vendedor s6 = new Vendedor("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000, d2);

            RegistroDeVendas r1 = new RegistroDeVendas(new DateTime(2018, 09, 25), 11000, VendaStatus.Faturado, s1);
            RegistroDeVendas r2 = new RegistroDeVendas(new DateTime(2018, 09, 4), 7000, VendaStatus.Faturado, s5);
            RegistroDeVendas r3 = new RegistroDeVendas(new DateTime(2018, 09, 13), 4000, VendaStatus.Cancelado, s4);
            RegistroDeVendas r4 = new RegistroDeVendas(new DateTime(2018, 09, 1), 8000, VendaStatus.Faturado, s1);
            RegistroDeVendas r5 = new RegistroDeVendas(new DateTime(2018, 09, 21), 3000, VendaStatus.Faturado, s3);
            RegistroDeVendas r6 = new RegistroDeVendas(new DateTime(2018, 09, 15), 2000, VendaStatus.Faturado, s1);
            RegistroDeVendas r7 = new RegistroDeVendas(new DateTime(2018, 09, 28), 13000, VendaStatus.Faturado, s2);
            RegistroDeVendas r8 = new RegistroDeVendas(new DateTime(2018, 09, 11), 4000, VendaStatus.Faturado, s4);
            RegistroDeVendas r9 = new RegistroDeVendas(new DateTime(2018, 09, 14), 11000, VendaStatus.Pendente, s6);
            RegistroDeVendas r10 = new RegistroDeVendas(new DateTime(2018, 09, 7), 9000, VendaStatus.Faturado, s6);
            RegistroDeVendas r11 = new RegistroDeVendas(new DateTime(2018, 09, 13), 6000, VendaStatus.Faturado, s2);
            RegistroDeVendas r12 = new RegistroDeVendas(new DateTime(2018, 09, 25), 7000, VendaStatus.Pendente, s3);
            RegistroDeVendas r13 = new RegistroDeVendas(new DateTime(2018, 09, 29), 10000, VendaStatus.Faturado, s4);
            RegistroDeVendas r14 = new RegistroDeVendas(new DateTime(2018, 09, 4), 3000, VendaStatus.Faturado, s5);
            RegistroDeVendas r15 = new RegistroDeVendas(new DateTime(2018, 09, 12), 4000, VendaStatus.Faturado, s1);
            RegistroDeVendas r16 = new RegistroDeVendas(new DateTime(2018, 10, 5), 2000, VendaStatus.Faturado, s4);
            RegistroDeVendas r17 = new RegistroDeVendas(new DateTime(2018, 10, 1), 12000, VendaStatus.Faturado, s1);
            RegistroDeVendas r18 = new RegistroDeVendas(new DateTime(2018, 10, 24), 6000, VendaStatus.Faturado, s3);
            RegistroDeVendas r19 = new RegistroDeVendas(new DateTime(2018, 10, 22), 8000, VendaStatus.Faturado, s5);
            RegistroDeVendas r20 = new RegistroDeVendas(new DateTime(2018, 10, 15), 8000, VendaStatus.Faturado, s6);
            RegistroDeVendas r21 = new RegistroDeVendas(new DateTime(2018, 10, 17), 9000, VendaStatus.Faturado, s2);
            RegistroDeVendas r22 = new RegistroDeVendas(new DateTime(2018, 10, 24), 4000, VendaStatus.Faturado, s4);
            RegistroDeVendas r23 = new RegistroDeVendas(new DateTime(2018, 10, 19), 11000, VendaStatus.Cancelado, s2);
            RegistroDeVendas r24 = new RegistroDeVendas(new DateTime(2018, 10, 12), 8000, VendaStatus.Faturado, s5);
            RegistroDeVendas r25 = new RegistroDeVendas(new DateTime(2018, 10, 31), 7000, VendaStatus.Faturado, s3);
            RegistroDeVendas r26 = new RegistroDeVendas(new DateTime(2018, 10, 6), 5000, VendaStatus.Faturado, s4);
            RegistroDeVendas r27 = new RegistroDeVendas(new DateTime(2018, 10, 13), 9000, VendaStatus.Pendente, s1);
            RegistroDeVendas r28 = new RegistroDeVendas(new DateTime(2018, 10, 7), 4000, VendaStatus.Faturado, s3);
            RegistroDeVendas r29 = new RegistroDeVendas(new DateTime(2018, 10, 23), 12000, VendaStatus.Faturado, s5);
            RegistroDeVendas r30 = new RegistroDeVendas(new DateTime(2018, 10, 12), 5000, VendaStatus.Faturado, s2);

            _context.Departamentos.AddRange(d1, d2, d3, d4);

            _context.Vendedores.AddRange(s1, s2, s3, s4, s5, s6);

            _context.RegistroDeVendas.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Models;
using MeuWebApp.Models.Enums;

namespace MeuWebApp.Data
{
    public class SeedingService
    {
        private MeuWebAppContext _context;

        public SeedingService(MeuWebAppContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            /* Se já existir algum registro na tabela Department ou
               se existir algum registro na tabela Oficial ou
               se existir algum registyro na tabela Venda */
            if(_context.Department.Any() || _context.Oficial.Any() || _context.Venda.Any())
            {
                return; // Se um dos argumentos for verdadeiro que dizer que o BD já foi populado, então não retorna nada.
            }
            Department d1 = new Department(1, "Computador");
            Department d2 = new Department(2, "Eletronico");
            Department d3 = new Department(3, "Moda");
            Department d4 = new Department(4, "Livros");

            Oficial o1 = new Oficial(1, "BobBrwn", "bob@gmail.com", new DateTime(1982, 4, 21), 1000.0, d1);
            Oficial o2 = new Oficial(2, "Maria", "maria@gmail.com", new DateTime(1980, 5, 01), 3500.0, d2);
            Oficial o3 = new Oficial(3, "Alex", "alex@gmail.com", new DateTime(1995, 1, 15), 2200.0, d1);
            Oficial o4 = new Oficial(4, "Martha", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Oficial o5 = new Oficial(5, "Donald", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Oficial o6 = new Oficial(6, "Eduardo", "eduardo@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            Venda v1 = new Venda(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Faturado, o1);
            Venda r1 = new Venda(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Faturado, o1);
            Venda r2 = new Venda(2, new DateTime(2018, 09, 4), 7000.0, SaleStatus.Faturado, o5);
            Venda r3 = new Venda(3, new DateTime(2018, 09, 13), 4000.0, SaleStatus.Cancelado, o4);
            Venda r4 = new Venda(4, new DateTime(2018, 09, 1), 8000.0, SaleStatus.Faturado, o1);
            Venda r5 = new Venda(5, new DateTime(2018, 09, 21), 3000.0, SaleStatus.Faturado, o3);
            Venda r6 = new Venda(6, new DateTime(2018, 09, 15), 2000.0, SaleStatus.Faturado, o1);
            Venda r7 = new Venda(7, new DateTime(2018, 09, 28), 13000.0, SaleStatus.Faturado, o2);
            Venda r8 = new Venda(8, new DateTime(2018, 09, 11), 4000.0, SaleStatus.Faturado, o4);
            Venda r9 = new Venda(9, new DateTime(2018, 09, 14), 11000.0, SaleStatus.Pendente, o6);
            Venda r10 = new Venda(10, new DateTime(2018, 09, 7), 9000.0, SaleStatus.Faturado, o6);
            Venda r11 = new Venda(11, new DateTime(2018, 09, 13), 6000.0, SaleStatus.Faturado, o2);
            Venda r12 = new Venda(12, new DateTime(2018, 09, 25), 7000.0, SaleStatus.Pendente, o3);
            Venda r13 = new Venda(13, new DateTime(2018, 09, 29), 10000.0, SaleStatus.Faturado, o4);
            Venda r14 = new Venda(14, new DateTime(2018, 09, 4), 3000.0, SaleStatus.Faturado, o5);
            Venda r15 = new Venda(15, new DateTime(2018, 09, 12), 4000.0, SaleStatus.Faturado, o1);
            Venda r16 = new Venda(16, new DateTime(2018, 10, 5), 2000.0, SaleStatus.Faturado, o4);
            Venda r17 = new Venda(17, new DateTime(2018, 10, 1), 12000.0, SaleStatus.Faturado, o1);
            Venda r18 = new Venda(18, new DateTime(2018, 10, 24), 6000.0, SaleStatus.Faturado, o3);
            Venda r19 = new Venda(19, new DateTime(2018, 10, 22), 8000.0, SaleStatus.Faturado, o5);
            Venda r20 = new Venda(20, new DateTime(2018, 10, 15), 8000.0, SaleStatus.Faturado, o6);
            Venda r21 = new Venda(21, new DateTime(2018, 10, 17), 9000.0, SaleStatus.Faturado, o2);
            Venda r22 = new Venda(22, new DateTime(2018, 10, 24), 4000.0, SaleStatus.Faturado, o4);
            Venda r23 = new Venda(23, new DateTime(2018, 10, 19), 11000.0, SaleStatus.Cancelado, o2);
            Venda r24 = new Venda(24, new DateTime(2018, 10, 12), 8000.0, SaleStatus.Faturado, o5);
            Venda r25 = new Venda(25, new DateTime(2018, 10, 31), 7000.0, SaleStatus.Faturado, o3);
            Venda r26 = new Venda(26, new DateTime(2018, 10, 6), 5000.0, SaleStatus.Faturado, o4);
            Venda r27 = new Venda(27, new DateTime(2018, 10, 13), 9000.0, SaleStatus.Pendente, o1);
            Venda r28 = new Venda(28, new DateTime(2018, 10, 7), 4000.0, SaleStatus.Faturado, o3);
            Venda r29 = new Venda(29, new DateTime(2018, 10, 23), 12000.0, SaleStatus.Faturado, o5);
            Venda r30 = new Venda(30, new DateTime(2018, 10, 12), 5000.0, SaleStatus.Faturado, o2);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Oficial.AddRange(o1, o2, o3, o4, o5, o6);
            _context.Venda.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15,
                r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            _context.SaveChanges();
        }
    }
}

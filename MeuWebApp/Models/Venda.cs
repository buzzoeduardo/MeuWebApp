using System;
using MeuWebApp.Models.Enums;

namespace MeuWebApp.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public double Montante { get; set; }
        public SaleStatus Status { get; set; }
        public Oficial Oficial { get; set; }

        public Venda()
        {
        }

        public Venda(int id, DateTime dataVenda, double montante, SaleStatus status, Oficial oficial)
        {
            Id = id;
            DataVenda = dataVenda;
            Montante = montante;
            Status = status;
            Oficial = oficial;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace MeuWebApp.Models
{
    public class Oficial
    {
        public int Id { get; set; }
        //public int Re { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public double SalarioBase { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();

        public Oficial()
        {
        }
        public Oficial(int id, string nome, string email, DateTime dataNasc, double salarioBase, Department department)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNasc = dataNasc;
            SalarioBase = salarioBase;
            Department = department;          
        }

        public void AddVendas(Venda vend)
        {
            Vendas.Add(vend);
        }
        public void RemoveVendas(Venda vend)
        {
            Vendas.Remove(vend);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(vend => vend.DataVenda >= inicial && vend.DataVenda <= final).
                Sum(vend => vend.Montante);
        }
    }
}

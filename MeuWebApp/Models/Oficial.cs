using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MeuWebApp.Models
{
    public class Oficial
    {
        public int Id { get; set; }
        //public int Re { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }
        public Department Department { get; set; }

        [Display(Name = "Departamento")]
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

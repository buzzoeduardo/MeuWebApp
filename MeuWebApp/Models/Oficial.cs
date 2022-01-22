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
       
        [Required(ErrorMessage = "{0} requerido.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O {0} deve ter entre {2} e {1} caracteres.")]
        //No ErrerMessage eu coloquei um 0 entre chaves, isso indica que ele nai pegar a string da minha propriedade, que no caso é o Nome.
        //As outras chaves vem na sequência dos parâmetros informados, no caso o 1 pega o "60" e o 2 o "3"
        public string Nome { get; set; }


        [Required(ErrorMessage = "{0} requerido.")]
        [EmailAddress(ErrorMessage = "Entre com um {0} válido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        
        [Required(ErrorMessage = "{0} requerido.")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]
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

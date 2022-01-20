using System.Collections.Generic;
using System;
using System.Linq;
namespace MeuWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Oficial> Oficiais { get; set; } = new List<Oficial>();

        public Department()
        {
        }
        public Department(int id, string name)
        {
            Id = id;
            Name = name;           
        }
        public void AddOficial(Oficial of)
        {
            Oficiais.Add(of);
        }
        public double TotalVendas(DateTime inicial, DateTime final)
        {
            return Oficiais.Sum(of => of.TotalVendas(inicial, final));
        }
    }
}

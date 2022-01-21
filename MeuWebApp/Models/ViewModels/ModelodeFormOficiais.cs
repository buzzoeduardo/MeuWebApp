
using System.Collections.Generic;

namespace MeuWebApp.Models.ViewModels
{
    public class ModelodeFormOficiais
    {
        public Oficial Oficial { get; set; }
        public ICollection<Department> Departments { get; set; }


    }
}

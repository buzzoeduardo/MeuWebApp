using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Data;
using MeuWebApp.Models;

namespace MeuWebApp.Services
{
    public class DepartmentService
    {
        private readonly MeuWebAppContext _context;

        public DepartmentService(MeuWebAppContext context)
        {
            _context = context;
        }
        public List<Department> FinsAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}

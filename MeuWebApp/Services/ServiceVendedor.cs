using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Data;
using MeuWebApp.Models;

namespace MeuWebApp.Services
{
    public class ServiceVendedor
    {
        private readonly MeuWebAppContext _context;

        public ServiceVendedor(MeuWebAppContext context)
        {
            _context = context;
        }

        public List<Oficial> FindAll()
        {
            return _context.Oficial.ToList();
        }
    }
}

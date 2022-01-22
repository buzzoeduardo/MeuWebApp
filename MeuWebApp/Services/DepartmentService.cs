using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Data;
using MeuWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuWebApp.Services
{
    public class DepartmentService
    {
        private readonly MeuWebAppContext _context;

        public DepartmentService(MeuWebAppContext context)
        {
            _context = context;
        }
        
        //Implementação Síncrona
     /* public List<Department> FinsAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
     */


        //Implementação Assíncrona
        public async Task<List<Department>> FinsAllAsync()//O Sufixo Async é um padrão adotado pela plataforma C#
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}

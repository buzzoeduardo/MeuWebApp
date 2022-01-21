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

        public void Inserir(Oficial obj)
        {           
            _context.Add(obj);//Inclue o ojb no Oficial
            _context.SaveChanges();//Salva no Banco de Dados
        }
        public Oficial FindById(int id)
        {
            return _context.Oficial.FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Oficial.Find(id);
            _context.Oficial.Remove(obj);
            _context.SaveChanges();
        }
    }
}

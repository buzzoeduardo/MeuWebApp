using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuWebApp.Data;
using MeuWebApp.Models;
using Microsoft.EntityFrameworkCore;
using MeuWebApp.Services.Exception;

namespace MeuWebApp.Services
{
    public class ServiceVendedor
    {
        private readonly MeuWebAppContext _context;

        public ServiceVendedor(MeuWebAppContext context)
        {
            _context = context;
        }

        public async Task<List<Oficial>> FindAllAsync()
        {
            return await _context.Oficial.ToListAsync();
        }

        /* Operação Síncrona
        public void Inserir(Oficial obj)
        {           
            _context.Add(obj);//Inclue o ojb no Oficial
            _context.SaveChanges();//Salva no Banco de Dados
        } */

        //Operação Assíncrona
        public async Task InserirAsync(Oficial obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }


        /* Síncrona
        public Oficial FindById(int id)
        {
            return _context.Oficial.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        } */

        //Assíncrona
        public async Task<Oficial> FindByIdAsync(int id)
        {
            return await _context.Oficial.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }


        /* Síncrona
        public void Remove(int id)
        {
            var obj = _context.Oficial.Find(id);
            _context.Oficial.Remove(obj);
            _context.SaveChanges();
        } */

        //Assíncrona
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Oficial.FindAsync(id);
            _context.Oficial.Remove(obj);
            await _context.SaveChangesAsync();
        }


        /* Sincrona
        public void Update(Oficial obj)
        {
            if (!_context.Oficial.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Cadastro inexistente");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
           
        } */


        public async Task UpdateAsync(Oficial obj)
        {
            bool temAlgum = await _context.Oficial.AnyAsync(x => x.Id == obj.Id);
            if (!temAlgum)
            {
                throw new NotFoundException("Cadastro inexistente");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}

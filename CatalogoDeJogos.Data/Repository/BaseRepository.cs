using CatalogoDeJogos.Data.ContextDB;
using CatalogoDeJogos.Model.Interfaces;
using CatalogoDeJogos.Model.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        protected readonly Contexto contexto;

        public BaseRepository(Contexto _contexto)
        {
            contexto = _contexto;
        }

        public virtual async Task<bool> Incluir(T entity)
        {
            try
            {
                contexto.Set<T>().Add(entity);
                await contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public virtual async Task<bool> Alterar(T entity)
        {
            contexto.Set<T>().Update(entity);
            await contexto.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<T>> SelecionarTudo()
        {
            return await contexto.Set<T>().ToListAsync();
        }

        public virtual async Task Deletar(T entity)
        {
            contexto.Set<T>().Remove(entity);
            await contexto.SaveChangesAsync();
        }

        public virtual async Task<T> SelecionarPorId(Guid id)
        {
            return await contexto.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            contexto.Dispose();
        }
    }
}

using CatalogoDeJogos.Data.ContextDB;
using CatalogoDeJogos.Model.Entities;
using CatalogoDeJogos.Model.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Data.Repository
{
    public class PlataformaRepository : BaseRepository<Plataforma>, IPlataformaRepository
    {
        private readonly Contexto _contexto;
        public PlataformaRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override async Task<bool> Incluir(Plataforma plataforma)
        {
            return await base.Incluir(plataforma);
        }

        public override async Task<bool> Alterar(Plataforma plataforma)
        {
            return await base.Alterar(plataforma);
        }

        public async Task<Plataforma> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        public override async Task<List<Plataforma>> SelecionarTudo()
        {
            return await base.SelecionarTudo();
        }

        public Plataforma ProcurarPorNome(string nome)
        {
            return _contexto.Consoles.FirstOrDefault(x => x.Nome == nome);
        }

        public Guid IdPorNome(string nome)
        {
            var plat = _contexto.Consoles.FirstOrDefault(x => x.Nome.Contains(nome));
            return plat.Id;
        }

        public override Task Deletar(Plataforma plataforma)
        {
            return base.Deletar(plataforma);
        }
    }
}

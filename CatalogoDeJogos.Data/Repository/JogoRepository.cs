using CatalogoDeJogos.Data.ContextDB;
using CatalogoDeJogos.Model.Entities;
using CatalogoDeJogos.Model.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Data.Repository
{
    public class JogoRepository : BaseRepository<Jogo>, IJogoRepository
    {
        private readonly Contexto _contexto;
        public JogoRepository(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override async Task<bool> Incluir(Jogo jogo)
        {
            return await base.Incluir(jogo);
        }

        public override async Task<bool> Alterar(Jogo jogo)
        {
            return await base.Alterar(jogo);
        }

        public async Task<Jogo> SelecionarPorId(Guid id)
        {
            return await base.SelecionarPorId(id);
        }

        public override async Task<List<Jogo>> SelecionarTudo()
        {
            return await base.SelecionarTudo();
        }

        public Jogo ProcurarPorNome(string nome)
        {
            return _contexto.Jogos.FirstOrDefault(x => x.Nome == nome);
        }

        public override Task Deletar(Jogo jogo)
        {
            return base.Deletar(jogo);
        }
    }
}

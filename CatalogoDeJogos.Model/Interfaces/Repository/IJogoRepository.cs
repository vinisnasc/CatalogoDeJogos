using CatalogoDeJogos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.Interfaces.Repository
{
    public interface IJogoRepository
    {
        Task<List<Jogo>> SelecionarTudo();
        Task<Jogo> SelecionarPorId(Guid id);
        Task<bool> Alterar(Jogo jogo);
        Task<bool> Incluir(Jogo jogo);
        Task Deletar(Jogo jogo);
        Jogo ProcurarPorNome(string nome);
    }
}

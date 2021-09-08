using CatalogoDeJogos.Model.DTO.ViewModel;
using CatalogoDeJogos.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.Interfaces.Repository
{
    public interface IPlataformaRepository
    {
        Plataforma ProcurarPorNome(string nome);
        Task<List<Plataforma>> SelecionarTudo();
        Task<Plataforma> SelecionarPorId(Guid id);
        Task<bool> Alterar(Plataforma plataforma);
        Task<bool> Incluir(Plataforma plataforma);
        Task Deletar(Plataforma plataforma);
        Guid IdPorNome(string nome);
    }
}

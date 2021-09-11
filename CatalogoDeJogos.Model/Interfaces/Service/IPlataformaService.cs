using CatalogoDeJogos.Model.DTO.ImputModel;
using CatalogoDeJogos.Model.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.Interfaces.Service
{
    public interface IPlataformaService
    {
        Task CadastrarPlataforma(PlataformaImputModel dto);
        Task AlterarPlataforma(Guid id, PlataformaImputModel dto);
        Task<PlataformaViewModel> SelecionarPorId(Guid id);
        Task DeletarPlataforma(Guid id);
        Task<List<PlataformaViewModel>> SelecionarTudo();
    }
}

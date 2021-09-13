using CatalogoDeJogos.Model.DTO.ImputModel;
using CatalogoDeJogos.Model.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Model.Interfaces.Service
{
    public interface IJogoService
    {
        Task CadastrarJogo(JogoInputModel dto);
        Task<JogoViewModel> AlterarJogo(Guid id, JogoInputModel dto);
        Task<List<JogoViewModel>> SelecionarTudo();
        Task<JogoViewModel> SelecionarPorId(Guid id);
        Task DeletarJogo(Guid id);
    }
}

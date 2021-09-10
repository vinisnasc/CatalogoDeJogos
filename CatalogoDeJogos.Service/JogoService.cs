using CatalogoDeJogos.Model.DTO.ImputModel;
using CatalogoDeJogos.Model.DTO.ViewModel;
using CatalogoDeJogos.Model.Entities;
using CatalogoDeJogos.Model.Entities.Enums;
using CatalogoDeJogos.Model.Exceptions;
using CatalogoDeJogos.Model.Interfaces.Repository;
using CatalogoDeJogos.Model.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Service
{
    public class JogoService : IJogoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JogoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CadastrarJogo(JogoImputModel dto)
        {
            Jogo jogo = _unitOfWork.JogoRepository.ProcurarPorNome(dto.Nome);

            if (jogo != null)
                throw new JogoJaCadastradoException();

            var game = new Jogo
            {
                Nome = dto.Nome,
                Id = Guid.NewGuid(),
                Produtora = dto.Produtora,
                Preco = dto.Preco,
                Genero = (Genero)Enum.Parse(typeof(Genero), dto.Genero),
                PlataformaConsole = _unitOfWork.PlataformaRepository.ProcurarPorNome(dto.Nome),
                IdPlataforma = _unitOfWork.PlataformaRepository.IdPorNome(dto.Nome)
            };

            await _unitOfWork.JogoRepository.Incluir(jogo);
        }

        public async Task<JogoViewModel> AlterarJogo(Guid id, JogoImputModel dto)
        {
            var jogo = await _unitOfWork.JogoRepository.SelecionarPorId(id);

            if (jogo == null)
                throw new JogoNaoExisteException();

            var nome = _unitOfWork.JogoRepository.ProcurarPorNome(dto.Nome);

            if (nome != null)
                throw new JogoJaCadastradoException();

            jogo.Nome = dto.Nome;
            jogo.Produtora = dto.Produtora;
            jogo.Preco = dto.Preco;
            jogo.Genero = (Genero)Enum.Parse(typeof(Genero), dto.Genero);
            jogo.PlataformaConsole = _unitOfWork.PlataformaRepository.ProcurarPorNome(dto.Nome);
            jogo.IdPlataforma = _unitOfWork.PlataformaRepository.IdPorNome(dto.Nome);

            await _unitOfWork.JogoRepository.Alterar(jogo);

            var jogoDto = new JogoViewModel();
            jogoDto.Id = jogo.Id;
            jogoDto.Genero = jogo.Genero;
            jogoDto.Nome = jogo.Nome;
            jogoDto.PlataformaConsole = jogo.PlataformaConsole;
            jogoDto.Preco = jogo.Preco;
            jogoDto.Produtora = jogo.Produtora;

            return jogoDto;
        }

        public async Task<List<JogoViewModel>> SelecionarTudo()
        {
            var list = await _unitOfWork.JogoRepository.SelecionarTudo();
            var listvm = new List<JogoViewModel>();
            
            foreach (var item in list)
            {
                JogoViewModel jogoVM = new()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Produtora = item.Produtora,
                    Preco = item.Preco,
                    Genero = item.Genero,
                    PlataformaConsole = item.PlataformaConsole
                };
                listvm.Add(jogoVM);
            }
            return listvm;
        }

        public async Task<JogoViewModel> SelecionarPorId(Guid id)
        {
            var jogo = await _unitOfWork.JogoRepository.SelecionarPorId(id);
            if (jogo == null)
                throw new JogoNaoExisteException();

            var jg = await _unitOfWork.JogoRepository.SelecionarPorId(id);

            var jogovm = new JogoViewModel();
            jogovm.Id = jg.Id;
            jogovm.Nome = jg.Nome;
            jogovm.Genero = jg.Genero;
            jogovm.PlataformaConsole = jg.PlataformaConsole;
            jogovm.Preco = jg.Preco;
            jogovm.Produtora = jg.Produtora;

            return jogovm;
        }

        public async Task DeletarJogo(Guid id)
        {
            var jogo = await _unitOfWork.JogoRepository.SelecionarPorId(id);
            if (jogo == null)
                throw new JogoNaoExisteException();

            await _unitOfWork.JogoRepository.Deletar(jogo);
        }

       
    }
}

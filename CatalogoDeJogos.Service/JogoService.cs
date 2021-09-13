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

        public async Task CadastrarJogo(JogoInputModel dto)
        {
            Jogo jogo = _unitOfWork.JogoRepository.ProcurarPorNome(dto.Nome);

            if (jogo != null)
                throw new JogoJaCadastradoException();

            var game = new Jogo
            {
                Nome = dto.Nome.ToLower().Trim(),
                Id = Guid.NewGuid(),
                Produtora = dto.Produtora.ToLower().Trim(),
                Preco = dto.Preco,
                Genero = (Genero)Enum.Parse(typeof(Genero), dto.Genero.ToLower().Trim()),
                PlataformaConsole = _unitOfWork.PlataformaRepository.ProcurarPorNome(dto.PlataformaConsole.ToLower().Trim()),
                IdPlataforma = _unitOfWork.PlataformaRepository.IdPorNome(dto.PlataformaConsole.ToLower().Trim())
            };

            await _unitOfWork.JogoRepository.Incluir(game);
        }

        public async Task<JogoViewModel> AlterarJogo(Guid id, JogoInputModel dto)
        {
            var jogo = await _unitOfWork.JogoRepository.SelecionarPorId(id);

            if (jogo == null)
                throw new JogoNaoExisteException();

            var nome = _unitOfWork.JogoRepository.ProcurarPorNome(dto.Nome.Trim().ToLower());

            if (nome != null && nome.Nome != jogo.Nome)
                throw new JogoJaCadastradoException();

            jogo.Nome = dto.Nome.ToLower().Trim();
            jogo.Produtora = dto.Produtora.ToLower().Trim();
            jogo.Preco = dto.Preco;
            jogo.Genero = (Genero)Enum.Parse(typeof(Genero), dto.Genero.ToLower().Trim());
            jogo.PlataformaConsole = _unitOfWork.PlataformaRepository.ProcurarPorNome(dto.Nome.ToLower().Trim());
            jogo.IdPlataforma = _unitOfWork.PlataformaRepository.IdPorNome(dto.PlataformaConsole.Trim().ToLower());

            await _unitOfWork.JogoRepository.Alterar(jogo);

            var jogoDto = new JogoViewModel();
            jogoDto.Id = jogo.Id;
            jogoDto.Genero = jogo.Genero.ToString();
            jogoDto.Nome = jogo.Nome;
            jogoDto.PlataformaConsole = jogo.PlataformaConsole.Nome;
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
                    Genero = item.Genero.ToString(),
                    PlataformaConsole = item.PlataformaConsole.Nome
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

            var plat = await _unitOfWork.PlataformaRepository.SelecionarPorId(jogo.IdPlataforma);

            var jogovm = new JogoViewModel();
            jogovm.Id = jogo.Id;
            jogovm.Nome = jogo.Nome;
            jogovm.Genero = jogo.Genero.ToString();
            jogovm.PlataformaConsole = plat.Nome;
            jogovm.Preco = jogo.Preco;
            jogovm.Produtora = jogo.Produtora;

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

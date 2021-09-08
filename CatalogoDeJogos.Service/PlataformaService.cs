using CatalogoDeJogos.Model.DTO.ImputModel;
using CatalogoDeJogos.Model.DTO.ViewModel;
using CatalogoDeJogos.Model.Entities;
using CatalogoDeJogos.Model.Exceptions;
using CatalogoDeJogos.Model.Interfaces.Repository;
using CatalogoDeJogos.Model.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogoDeJogos.Service
{
    public class PlataformaService : IPlataformaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PlataformaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CadastrarPlataforma(PlataformaImputModel dto)
        {
            Plataforma plat = _unitOfWork.PlataformaRepository.ProcurarPorNome(dto.Nome.Trim().ToLower());

            if (plat != null)
                throw new PlataformaJaCadastradaException();

            var console = new Plataforma
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Desenvolvedor = dto.Desenvolvedor,
                Ano = dto.Ano
            };

            await _unitOfWork.PlataformaRepository.Incluir(console);
        }

        public async Task AlterarPlataforma(Guid id, PlataformaImputModel dto)
        {
            var plat = await _unitOfWork.PlataformaRepository.SelecionarPorId(id);

            if (plat == null)
                throw new PlataformaNaoExisteException();

            var nome = _unitOfWork.PlataformaRepository.ProcurarPorNome(dto.Nome);

            if (nome != null)
                throw new PlataformaJaCadastradaException();

            plat.Nome = dto.Nome;
            plat.Desenvolvedor = dto.Desenvolvedor;
            plat.Ano = dto.Ano;

            await _unitOfWork.PlataformaRepository.Alterar(plat);
        }

        public async Task<List<PlataformaViewModel>> SelecionarTudo()
        {
            var list = await _unitOfWork.PlataformaRepository.SelecionarTudo();
            var listvm = new List<PlataformaViewModel>();

            foreach (var item in list)
            {
                PlataformaViewModel platVM = new()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Desenvolvedor = item.Desenvolvedor,
                    Ano = item.Ano
                };
                listvm.Add(platVM);
            }
            return listvm;
        }

        public async Task<PlataformaViewModel> SelecionarPorId(Guid id)
        {
            var plat = await _unitOfWork.PlataformaRepository.SelecionarPorId(id);
            if (plat == null)
                throw new PlataformaNaoExisteException();

            var plataf = await _unitOfWork.PlataformaRepository.SelecionarPorId(id);

            var platVM = new PlataformaViewModel();
            platVM.Id = plataf.Id;
            platVM.Nome = plataf.Nome;
            platVM.Ano = plataf.Ano;
            platVM.Desenvolvedor = plataf.Desenvolvedor;

            return platVM;
        }

        public async Task DeletarPlataforma(Guid id)
        {
            var plat = await _unitOfWork.PlataformaRepository.SelecionarPorId(id);
            if (plat == null)
                throw new PlataformaNaoExisteException();

            await _unitOfWork.PlataformaRepository.Deletar(plat);
        }
    }
}

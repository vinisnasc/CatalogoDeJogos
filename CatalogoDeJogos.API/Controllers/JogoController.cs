using CatalogoDeJogos.Model.DTO.ImputModel;
using CatalogoDeJogos.Model.DTO.ViewModel;
using CatalogoDeJogos.Model.Entities;
using CatalogoDeJogos.Model.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatalogoDeJogos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }
        
        /// <summary>
        /// Mostra todos os jogos no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<JogoViewModel>> Get()
        {
            return await _jogoService.SelecionarTudo();
        }

        /// <summary>
        /// Mostra os dados de um jogo ao informar seu Id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var jogo = await _jogoService.SelecionarPorId(id);
            return Ok(jogo);
        }

        /// <summary>
        /// Cadastra um novo jogo no banco de dados
        /// </summary>
        /// <param name="dto">Dados do jogo</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] JogoInputModel dto)
        {
            await _jogoService.CadastrarJogo(dto);
            return Ok();
        }

        /// <summary>
        /// Atualiza um jogo
        /// </summary>
        /// <param name="id">Id do jogo a ser atualizado</param>
        /// <param name="dto">Novos dados do jogo</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromQuery] JogoInputModel dto)
        {
            var jogo = await _jogoService.AlterarJogo(id, dto);
            return Ok(jogo);
        }

        /// <summary>
        /// Deleta um jogo informando seu id
        /// </summary>
        /// <param name="id">Id do jogo</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _jogoService.DeletarJogo(id);
        }
    }
}

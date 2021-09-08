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
        
        [HttpGet]
        public async Task<IEnumerable<JogoViewModel>> Get()
        {
            return await _jogoService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var jogo = await _jogoService.SelecionarPorId(id);
            return Ok(jogo);
        }

        // POST api/<JogoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JogoImputModel dto)
        {
            await _jogoService.CadastrarJogo(dto);
            return Ok();
        }

        // PUT api/<JogoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JogoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

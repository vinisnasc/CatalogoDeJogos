using CatalogoDeJogos.Model.DTO.ViewModel;
using CatalogoDeJogos.Model.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaService _plataformaService;

        public PlataformaController(IPlataformaService plataformaService)
        {
            _plataformaService = plataformaService;
        }

        [HttpGet]
        public async Task<IEnumerable<PlataformaViewModel>> Get()
        {
            return await _plataformaService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var jogo = await _plataformaService.SelecionarPorId(id);
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
        public async Task<IActionResult> Put(Guid id, [FromBody] JogoImputModel dto)
        {
            var jogo = await _jogoService.AlterarJogo(id, dto);
            return Ok(jogo);
        }

        // DELETE api/<JogoController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _jogoService.DeletarJogo(id);
        }
    }
}

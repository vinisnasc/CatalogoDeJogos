using CatalogoDeJogos.Model.DTO.ImputModel;
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

        /// <summary>
        /// Mostra todos os consoles cadastrados no banco de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<PlataformaViewModel>> Get()
        {
            return await _plataformaService.SelecionarTudo();
        }

        /// <summary>
        /// Mostra os dados de um console, ao informar seu Id
        /// </summary>
        /// <param name="id">Id do console desejado</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var plat = await _plataformaService.SelecionarPorId(id);
            return Ok(plat);
        }

        /// <summary>
        /// Cadastra um novo Console no banco de dados
        /// </summary>
        /// <param name="dto">Dados do console</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] PlataformaImputModel dto)
        {
            await _plataformaService.CadastrarPlataforma(dto);
            return Ok();
        }

        /// <summary>
        /// Atualiza um console, ao informar seu Id
        /// </summary>
        /// <param name="id">Id do console</param>
        /// <param name="dto">Novos dados do console</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromQuery] PlataformaImputModel dto)
        {
            var plat = await _plataformaService.AlterarPlataforma(id, dto);
            return Ok(plat);
        }
    }
}

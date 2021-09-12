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

        [HttpGet]
        public async Task<IEnumerable<PlataformaViewModel>> Get()
        {
            return await _plataformaService.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var plat = await _plataformaService.SelecionarPorId(id);
            return Ok(plat);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlataformaImputModel dto)
        {
            await _plataformaService.CadastrarPlataforma(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PlataformaImputModel dto)
        {
            var plat = await _plataformaService.AlterarPlataforma(id, dto);
            return Ok(plat);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        private IRacaRepository _racaRepository { get; set; }

        public RacaController()
        {
            _racaRepository = new RacaRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_racaRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idRaca}")]
        public IActionResult BuscarPorId(int idRaca)
        {
            try
            {
                return Ok(_racaRepository.BuscarPorId(idRaca));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Raca novaRaca)
        {
            try
            {
                _racaRepository.Cadastrar(novaRaca);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idRaca}")]
        public IActionResult Atualizar(int idRaca, Raca racaAtualizada)
        {
            try
            {
                _racaRepository.Atualizar(idRaca, racaAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idRaca}")]
        public IActionResult Deletar(int idRaca)
        {
            try
            {
                _racaRepository.Deletar(idRaca);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}

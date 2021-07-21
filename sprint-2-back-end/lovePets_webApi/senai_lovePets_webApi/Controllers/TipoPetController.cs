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
    public class TipoPetController : ControllerBase
    {
        private ITipoPetRepository _tipoPetRepository { get; set; }

        public TipoPetController()
        {
            _tipoPetRepository = new TipoPetRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_tipoPetRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idTipoPet}")]
        public IActionResult BuscarPorId(int idTipoPet)
        {
            try
            {
                return Ok(_tipoPetRepository.BuscarPorId(idTipoPet));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(TipoPet novoTipoPet)
        {
            try
            {
                _tipoPetRepository.Cadastrar(novoTipoPet);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idTipoPet}")]
        public IActionResult Atualizar(int idTipoPet, TipoPet TipoPetAtualizado)
        {
            try
            {
                _tipoPetRepository.Atualizar(idTipoPet, TipoPetAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idPet}")]
        public IActionResult Deletar(int idTipoPet)
        {
            try
            {
                _tipoPetRepository.Deletar(idTipoPet);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}

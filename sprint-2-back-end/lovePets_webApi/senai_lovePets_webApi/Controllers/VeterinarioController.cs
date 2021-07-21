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
    public class VeterinarioController : ControllerBase
    {
        private IVeterinarioRepository _veterinarioRepository { get; set; }

        public VeterinarioController()
        {
            _veterinarioRepository = new VeterinarioRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_veterinarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Busca um atendimento através do seu ID
        /// </summary>
        /// <param name="idVeterinario">ID do atendimento que será buscado</param>
        /// <returns>Um atendimento encontrado com o status code 200 - Ok</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{idVeterinario}")]
        public IActionResult BuscarPorId(int idVeterinario)
        {
            try
            {
                return Ok(_veterinarioRepository.BuscarPorId(idVeterinario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo atendimento
        /// </summary>
        /// <param name="novoVeterinario">Objeto com as novas informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Veterinario novoVeterinario)
        {
            try
            {
                _veterinarioRepository.Cadastrar(novoVeterinario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Atualiza um atendimento
        /// </summary>
        /// <param name="idVeterinario">ID do atendimento que será atualizado</param>
        /// <param name="veterinarioAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{idVeterinario}")]
        public IActionResult Atualizar(int idVeterinario, Veterinario veterinarioAtualizado)
        {
            try
            {
                _veterinarioRepository.Atualizar(idVeterinario, veterinarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Deleta um atendimento existente
        /// </summary>
        /// <param name="idVeterinario">ID do atendimento que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{idVeterinario}")]
        public IActionResult Deletar(int idVeterinario)
        {
            try
            {
                _veterinarioRepository.Deletar(idVeterinario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}

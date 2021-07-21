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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [Authorize(Roles = "1")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarBuscarPorEmailSenha()
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorEmailSenha());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}

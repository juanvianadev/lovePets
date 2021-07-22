using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um usuário através do id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            // Verifica se o e-mail do usuário foi informado
            if (usuarioAtualizado.Email != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            // Verifica se a senha do usuário foi informado
            if (usuarioAtualizado.Senha != null)
            {
                // Atribui os novos valores ao campos existentes
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.Find(idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}

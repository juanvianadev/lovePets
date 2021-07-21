using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idVeterinario, Veterinario VeterinarioAtualizado)
        {
            Veterinario veterinarioBuscado = BuscarPorId(idVeterinario);

            if (VeterinarioAtualizado.Crmv != null)
            {
                veterinarioBuscado.Crmv = VeterinarioAtualizado.Crmv;
            }

            if (VeterinarioAtualizado.NomeVeterinario != null)
            {
                veterinarioBuscado.NomeVeterinario = VeterinarioAtualizado.NomeVeterinario;
            }

        }

        public Veterinario BuscarPorId(int idVeterinario)
        {
            return ctx.Veterinarios.Find(idVeterinario);
        }

        public void Cadastrar(Veterinario novoVeterinario)
        {
            ctx.Veterinarios.Add(novoVeterinario);

            ctx.SaveChanges();
        }

        public void Deletar(int idVeterinario)
        {
            ctx.Veterinarios.Remove(BuscarPorId(idVeterinario));

            ctx.SaveChanges();
        }

        public List<Veterinario> ListarTodos()
        {
            return ctx.Veterinarios.ToList();
        }
    }
}

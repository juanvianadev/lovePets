using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class DonoRepository : IDonoRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idDono, Dono DonoAtualizado)
        {
            Dono DonoBuscar = BuscarPorId(idDono);

            if (DonoAtualizado.NomeDono != null)
            {
                DonoBuscar.NomeDono = DonoAtualizado.NomeDono;
            }
        }

        public Dono BuscarPorId(int idDono)
        {
            return ctx.Donos.Find(idDono);
        }

        public void Cadastrar(Dono novoDono)
        {
            ctx.Donos.Add(novoDono);

            ctx.SaveChanges();
        }

        public void Deletar(int idDono)
        {
            ctx.Donos.Remove(BuscarPorId(idDono));

            ctx.SaveChanges();
        }

        public List<Dono> ListarTodos()
        {
            return ctx.Donos.ToList();
        }
    }
}

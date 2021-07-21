using Microsoft.EntityFrameworkCore;
using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class RacaRepository : IRacaRepository
    {
        lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(int idRaca, Raca RacaAtualizada)
        {
            Raca racaBuscado = BuscarPorId(idRaca);

            if (RacaAtualizada.NomeRaca != null)
            {
                racaBuscado.NomeRaca = RacaAtualizada.NomeRaca;
            }
        }

        public Raca BuscarPorId(int idRaca)
        {
            return ctx.Racas.Find(idRaca);
        }

        public void Cadastrar(Raca novaRaca)
        {
            ctx.Racas.Add(novaRaca);

            ctx.SaveChanges();
        }

        public void Deletar(int idRaca)
        {
            ctx.Racas.Remove(BuscarPorId(idRaca));

            ctx.SaveChanges();
        }

        public List<Raca> ListarTodos()
        {
            return ctx.Racas.ToList();
        }
    }
}

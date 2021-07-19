using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idPet, Pet PetAtualizado)
        {
            Pet PetBuscar = BuscarPorId(idPet);

            if (PetAtualizado.NomePet != null)
            {
                PetBuscar.NomePet = PetAtualizado.NomePet;
            }

            if (PetAtualizado.DataNascimento <= DateTime.Today)
            {
                PetBuscar.DataNascimento = PetAtualizado.DataNascimento;
            }

            if (PetAtualizado.Ra != null)
            {
                PetBuscar.Ra = PetAtualizado.Ra;
            }
        }

        public Pet BuscarPorId(int idPet)
        {
            return ctx.Pets.Find(idPet);
        }

        public void Cadastrar(Pet novoPet)
        {
            ctx.Pets.Add(novoPet);

            ctx.SaveChanges();
        }

        public void Deletar(int idPet)
        {
            ctx.Pets.Remove(BuscarPorId(idPet));

            ctx.SaveChanges();
        }

        public List<Pet> ListarTodos()
        {
            return ctx.Pets.ToList();
        }
    }
}

using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IPetRepository
    {
        List<Pet> ListarTodos();

        Pet BuscarPorId(int idPet);

        void Cadastrar(Pet novoPet);

        void Atualizar(int idPet, Pet PetAtualizado);

        void Deletar(int idPet);
    }
}

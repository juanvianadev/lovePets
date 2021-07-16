using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IDonoRepository
    {
        List<Dono> ListarTodos();

        Dono BuscarPorId(int idDono);

        void Cadastrar(Dono novoDono);

        void Atualizar(int idDono, Dono DonoAtualizado);

        void Deletar(int idDono);
    }
}

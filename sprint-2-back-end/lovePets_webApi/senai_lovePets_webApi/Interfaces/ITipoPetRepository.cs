using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface ITipoPetRepository
    {
        List<TipoPet> ListarTodos();

        TipoPet BuscarPorId(int idTipoPet);

        void Cadastrar(TipoPet novoTipoPet);

        void Atualizar(int idTipoPet, TipoPet TipoPetAtualizado);

        void Deletar(int idTipoPet);
    }
}

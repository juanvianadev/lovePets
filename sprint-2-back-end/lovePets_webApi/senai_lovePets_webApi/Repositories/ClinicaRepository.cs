using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscar = BuscarPorId(idClinica);

            if (clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscar.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            if (clinicaAtualizada.Cnpj != null)
            {
                clinicaBuscar.Cnpj = clinicaAtualizada.Cnpj;
            }

            if (clinicaAtualizada.Endereco != null)
            {
                clinicaBuscar.Endereco = clinicaAtualizada.Endereco;
            }
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.Find(idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            ctx.Clinicas.Remove(BuscarPorId(idClinica));

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}

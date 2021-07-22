import { Component } from "react";

export default class MeusAtendimentos extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicialEstado
      listaAtendimentos : []
    };
  };

  buscarAtendimentos = () => {
    console.log('Esta função traz todos os atendimentos.');

    fetch('http://localhost:5000/api/atendimentos/meus', {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status !== 200) {
        throw Error();
      };

      return resposta.json();
    })

    .then(resposta => this.setState({ listaAtendimentos : resposta }))
    
    .catch(erro => console.log(erro));
  };

  componentDidMount(){
    this.buscarAtendimentos();
  };


  render(){
    return(
      <div>
        <h1>Gerenciamento de Atendimentos</h1>

        <section>
          <h2>Lista de atendimentos</h2>

          <table>

            <thead>
              <tr>
                <th>#</th>
                <th>Veterinário</th>
                <th>Pet</th>
                <th>Descrição</th>
                <th>Data do atendimento</th>
                <th>Situação</th>
              </tr>
            </thead>

            <tbody>

              {
                this.state.listaAtendimentos.map( (atendimento) => {
                  return (
                    <tr key={atendimento.idAtendimento}>
                      <td>{atendimento.idAtendimento}</td>
                      <td>{atendimento.idVeterinarioNavigation.nomeVeterinario}</td>
                      <td>{atendimento.idPetNavigation.nomePet}</td>
                      <td>{atendimento.descricao}</td>
                      <td>{Intl.DateTimeFormat("pt-BR", {
                        year: 'numeric', month: 'numeric', day: 'numeric',
                        hour: 'numeric', minute: 'numeric',
                        hour12: false
                      }).format(new Date(atendimento.dataAtendimento))}</td>
                      <td>{atendimento.idSituacaoNavigation.nomeSituacao}</td>
                    </tr>
                  )
                } )
              }

            </tbody>

          </table>
        </section>

        <section>
          <h2>Cadastro de atendimentos</h2>

          {/* Formulário de cadastro */}

        </section>
      </div>
    )
  }
}

// export default Atendimentos;
import { Component } from "react";
import axios from "axios";

export default class Atendimentos extends Component{
  constructor(props){
    super(props);
    this.state = {
      // nomeEstado : valorInicialEstado
      listaAtendimentos : [],
      idVeterinario : 0,
      idPet : 0,
      descricao : '',
      data : new Date(),
      hora : '',
      idSituacao : 0,
      listaVeterinarios : [],
      listaPets : [],
      listaSituacoes : []
    };
  };

  buscarAtendimentos = () => {
    console.log('Esta função traz todos os atendimentos.');

    fetch('http://localhost:5000/api/atendimentos', {
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

  buscarVeterinarios = () => {
    fetch('http://localhost:5000/api/veterinario', {
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

    .then(resposta => this.setState({ listaVeterinarios : resposta }))
    
    .catch(erro => console.log(erro));
  };

  buscarPets = () => {
    fetch('http://localhost:5000/api/pet', {
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

    .then(resposta => this.setState({ listaPets : resposta }))
    
    .catch(erro => console.log(erro));
  };

  buscarSituacoes = () => {
    fetch('http://localhost:5000/api/situacao', {
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

    .then(resposta => this.setState({ listaSituacoes : resposta }))
    
    .catch(erro => console.log(erro));
  };

  componentDidMount(){
    this.buscarAtendimentos();
    this.buscarVeterinarios();
    this.buscarPets();
    this.buscarSituacoes();
  };

  cadastrarAtendimento = (event) => {
    event.preventDefault();

    let novoAtendimento = {
      // chave (como está na API) : valor que será cadastrado
      idVeterinario           :     this.state.idVeterinario,
      idPet                   :     this.state.idPet,
      descricao               :     this.state.descricao,
      dataAtendimento         :     this.state.data + 'T' + this.state.hora,
      idSituacao              :     this.state.idSituacao
    };

    axios.post('http://localhost:5000/api/atendimentos', novoAtendimento, {
      headers : {
        'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
      }
    })

    .then(resposta => {
      if (resposta.status === 201) {
        console.log('Um novo atendimento foi agendado!');
      }
    })

    .catch(erro => console.log(erro))

    .then(this.buscarAtendimentos);
  };

  atualizaStateCampo = (campo) => {
    //   exemplo       idVeterinario    :         1
    this.setState({ [campo.target.name] : campo.target.value })
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
          <form onSubmit={this.cadastrarAtendimento}>

            {/* 
              Outra forma 

            <input 
              // Veterinário
              type="number"
              name="idVeterinario"
              value={this.state.idVeterinario}
              onChange={this.atualizaStateCampo}
            /> 
            
            */}

            <select
              name="idVeterinario"
              value={this.state.idVeterinario}
              onChange={this.atualizaStateCampo}
            >
              <option value="0">Selecione o veterinário que fará o atendimento</option>

              {
                this.state.listaVeterinarios.map( (veterinario) => {
                  return(
                    <option key={veterinario.idVeterinario} value={veterinario.idVeterinario}>{veterinario.nomeVeterinario} - {veterinario.crmv}</option>
                  )
                } )
              }
              
            </select>

            <input 
              // Pet
              type="number"
              name="idPet"
              value={this.state.idPet}
              onChange={this.atualizaStateCampo}
            />

            <input 
              // Descrição
              type="text"
              name="descricao"
              value={this.state.descricao}
              onChange={this.atualizaStateCampo}
            />

            <input 
              // Data do atendimento
              type="date"
              name="data"
              value={this.state.data}
              onChange={this.atualizaStateCampo}
            />

            <input 
              // Hora do atendimento
              type="time"
              name="hora"
              value={this.state.hora}
              onChange={this.atualizaStateCampo}
            />

            <input 
              // Pet
              type="number"
              name="idSituacao"
              value={this.state.idSituacao}
              onChange={this.atualizaStateCampo}
            />

            <button type="submit">
              Cadastrar
            </button>

          </form>

        </section>
      </div>
    )
  }
}

// export default Atendimentos;
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
        razaoSocial : '',
        hora : '',
        idSituacao : 0,
        listaVeterinarios : [],
        listaPets : [],
        listaSituacoes : []
      };
    };

}

buscarAtendimentos = () => {
    console.log('Esta função traz todos os atendimentos.');

    fetch('http://localhost:5000/api/clinica', {
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

    .then(resposta => this.setState({ listaClinicas : resposta }))
    
    .catch(erro => console.log(erro));
  };
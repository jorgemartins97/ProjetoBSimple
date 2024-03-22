using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain;

    public class Associacao : IAssociacao
    {
        private IColaborator _colaborator;
 
        private IProjeto _projeto;

        public Associacao(IColaborator colab,IProjeto projeto){
            if(colab!=null && projeto!=null){
                _colaborator = colab;
                _projeto = projeto;
            }
            else
                throw new ArgumentException("Invalid argument: colaborator and project must be non null");
        }

        // public string getNomeColaborador() {
        // return _colaborator.getName();
        // }
 
        // public IColaborator getColaborador(){
        //     return _colaborator;
        // }
 
        // public IProjeto GetProjeto(){
        //     return _projeto;
        // }
    }

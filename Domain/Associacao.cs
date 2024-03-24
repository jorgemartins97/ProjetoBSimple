using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain;

    public class Associacao : IAssociacao
    {
        private IColaborator _colaborator;
 

        public Associacao(IColaborator colab){
            if(colab!=null ){
                _colaborator = colab;

            }
            else
                throw new ArgumentException("Invalid argument: colaborator must be non null");
        }

        public IColaborator getColaborador(){
            return _colaborator;
        }

        //Verificar se o colaborador é o mesmo ou nao 
        public bool isContainedColaborator(IColaborator colaborator)
        {
            return _colaborator == colaborator;
        }
    }


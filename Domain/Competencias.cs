using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain;

    public class Competencias : ICompetencias
    {
          private string _strDescriçao;
        private int _nivel;
    
        public Competencias(string strDescriçao, int nivel) {
            if ( isValidParameters(strDescriçao, nivel)){
                _strDescriçao = strDescriçao;
                _nivel = nivel;
            }
            else 
                throw new ArgumentException ("Invalid arguments");
        }

        private bool isValidParameters(string strDescriçao, int nivel) {
            if( strDescriçao==null ||
                string.IsNullOrWhiteSpace(strDescriçao) ||
                ContainsAny(strDescriçao, ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"] ))
                return false;
        
            if(nivel<0 || nivel>5 )
         return false; 

            return true;
        }

        private bool ContainsAny(string stringToCheck, params string[] parameters)
	    {
		    return parameters.Any(parameter => stringToCheck.Contains(parameter));
	    }
    }

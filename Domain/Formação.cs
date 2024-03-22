using Domain.interfaces;

namespace Domain;

    public class Formacao : IFormacao
    {
         private string _strDescriçao;
         private List<ICompetencias> _competenciasPrevias = new List<ICompetencias>();
         private List<ICompetencias> _competenciasAdquirir = new List<ICompetencias>();
         public List<PeriodoFormacao> _periodoDeFormacao = new List<PeriodoFormacao>();

        public Formacao (string strDescriçao) {
            if(isValidParameters(strDescriçao)) {
                _strDescriçao = strDescriçao;
                _competenciasPrevias = new List<ICompetencias>();
                _competenciasAdquirir = new List<ICompetencias>();
            }
            else
                throw new ArgumentException("Invalid arguments.");
        }

        private bool isValidParameters(string description)
        {
            if (description == null ||
                string.IsNullOrWhiteSpace(description))
                return false;
            return true;
        }

        public PeriodoFormacao AddPeriodoFormacao(IPeriodoFormacaoFactory pfFactory, DateOnly dataInicio, DateOnly dataFim){
        PeriodoFormacao periodoFormacao = pfFactory.NewPeriodoFormacao(dataInicio, dataFim);
        _periodoDeFormacao.Add(periodoFormacao);
        return periodoFormacao;
        }

        public void AddCompetenciaPrevia(string strDescricao, int nivel)
        {
        // Verifica se uma competência com a mesma descrição já está na lista
        foreach(var competenciap in _competenciasPrevias)
        {
            if (competenciap.isCompExist(strDescricao, nivel))
            {
                throw new ArgumentException("Esta competência já existe.");
            }
        }       
        // Se não existir, adiciona a nova competência à lista
        Competencias novaCompetencia = new Competencias(strDescricao, nivel);
        _competenciasPrevias.Add(novaCompetencia);
        }

        public void AddCompetenciaAdquirir(string strDescricao, int nivel)
        {
            //verificar primeiro se a compAdquirir ja existe nas previas
            foreach(var compAdquirir in _competenciasPrevias)
            {
                if (compAdquirir.isCompExist(strDescricao, nivel))
                {
                    throw new ArgumentException("Esta competência já existe.");

                }
            }  

            //caso nao exista nas previas vamos as compAdquirir verificar se existe
            foreach(var competencia in _competenciasAdquirir)
            {
                if (competencia.isCompExist(strDescricao, nivel))
                {
                    throw new ArgumentException("Esta competência já existe.");

                }
            }  
            //nao existindo nas duas listas adiciona-se à lista de comp a adquirir
            Competencias novaCompAdquirir = new Competencias(strDescricao, nivel);
            _competenciasAdquirir.Add(novaCompAdquirir);

        }
    }
    
        
    

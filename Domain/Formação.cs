using Domain.interfaces;

namespace Domain;

    public class Formacao : IFormacao
    {
         private string _strDescriçao;
         private List<ICompetencias> _competencias = new List<ICompetencias>();
         public List<PeriodoFormacao> _periodoDeFormacao = new List<PeriodoFormacao>();

        public Formacao (string strDescriçao) {
            if(isValidParameters(strDescriçao)) {
                _strDescriçao = strDescriçao;
                _competencias = new List<ICompetencias>();
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

        public void AddCompetencia(string strDescricao, int nivel)
        {
        // Verifica se uma competência com a mesma descrição já está na lista
        foreach(var competencia in _competencias)
        {
            if (competencia.isCompExist(strDescricao, nivel))
            {
                throw new ArgumentException("Esta competência já existe.");
            }
        }       
        // Se não existir, adiciona a nova competência à lista
        Competencias novaCompetencia = new Competencias(strDescricao, nivel);
        _competencias.Add(novaCompetencia);
        }
    }
    
        
    

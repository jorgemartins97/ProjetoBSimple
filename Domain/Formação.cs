using Domain.interfaces;

namespace Domain;

    public class Formacao : IFormacao
    {
         private string _strDescriçao;
         private List<ICompetencias> _competencias;
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

        public void addCompetencia(ICompetencias competencias){
        _competencias.Add(competencias);
    }
        
    }

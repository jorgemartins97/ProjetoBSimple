using Domain.interfaces;

namespace Domain;

    public class Formacao : IFormacao
    {
         public string _strDescriçao;
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

        public IPeriodoFormacao AddPeriodoFormacao(IPeriodoFormacaoFactory pfFactory, DateOnly dataInicio, DateOnly dataFim){
            var periodoFormacao = pfFactory.NewPeriodoFormacao(dataInicio, dataFim);
            return periodoFormacao;
        // PeriodoFormacao periodoFormacao = pfFactory.NewPeriodoFormacao(dataInicio, dataFim);
        // _periodoDeFormacao.Add(periodoFormacao);
        // return periodoFormacao;
        }

        public List<ICompetencias> AddCompetenciaPrevia(ICompetencias competencias)
        {
            if(competencias == null)
                throw new ArgumentException("Competencias nao podem ser nulas!");
                _competenciasAdquirir.Add(competencias);
            return _competenciasAdquirir.ToList();
            
        }

        public List<ICompetencias> AddCompetenciaAdquirir(List<ICompetencias> competencias)
        {
            ValidarListaCompetencias(competencias);
            foreach (var comp in competencias) 
                _competenciasPrevias.Add(comp);
            return _competenciasPrevias.ToList();

        }

        //Metodo para verificar se a competencia existe
        private void ValidarListaCompetencias (List<ICompetencias> competencias)
        {
            if (competencias == null || !competencias.Any())
                throw new ArgumentException("A lista nao pode ser vazia ou nula");
            if (competencias.Any(competencias => _competenciasPrevias.Contains(competencias) || _competenciasAdquirir.Contains(competencias)))
                throw new InvalidOperationException("Uma ou mais competencias ja estao adicionadas.");
        }
    }
    
        
    

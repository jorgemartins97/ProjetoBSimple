namespace Domain.interfaces
{
    public interface IFormacao
    {
        public IPeriodoFormacao AddPeriodoFormacao(IPeriodoFormacaoFactory pfFactory, DateOnly dataIncio, DateOnly dataFim);
        public List<ICompetencias> AddCompetenciaPrevia(ICompetencias competencias);
        public List<ICompetencias> AddCompetenciaAdquirir(List<ICompetencias> competencias);
    }
}
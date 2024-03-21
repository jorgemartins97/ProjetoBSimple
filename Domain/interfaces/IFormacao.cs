namespace Domain.interfaces
{
    public interface IFormacao
    {
        PeriodoFormacao AddPeriodoFormacao(IPeriodoFormacaoFactory pfFactory, DateOnly dataIncio, DateOnly dataFim);
    }
}
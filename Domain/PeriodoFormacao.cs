using Domain.interfaces;

namespace Domain;

public class PeriodoFormacao : IPeriodoFormacao
{
    public DateOnly _dataInicio;
    public DateOnly _datafim;

        public PeriodoFormacao(DateOnly dataInicio, DateOnly dataFim){
            if( dataInicio < dataFim){
                _dataInicio = dataInicio;
                _datafim = dataFim;
            }
            else
                throw new ArgumentException("invalid arguments: start date >= end date.");
        }

}
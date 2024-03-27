using Domain.interfaces;

namespace Domain;

public class PeriodoFormacao : IPeriodoFormacao
{
    private DateOnly _dataInicio;
    private DateOnly _datafim;

        public PeriodoFormacao(DateOnly dataInicio, DateOnly dataFim){
            if( dataInicio < dataFim){
                _dataInicio = dataInicio;
                _datafim = dataFim;
            }
            else
                throw new ArgumentException("invalid arguments: start date >= end date.");
        }

}
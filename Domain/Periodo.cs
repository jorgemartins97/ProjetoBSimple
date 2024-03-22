using Domain.interfaces;

namespace Domain;

public class Periodo : IPeriodo
{
    DateOnly _dataInicio;
    DateOnly _dataFim;

    public Periodo(DateOnly dataInicio, DateOnly dataFim)
    {
        if( isValidParameters(dataInicio, dataFim )) {
            _dataInicio = dataInicio;
            _dataFim = dataFim;
        }
        else
            throw new ArgumentException("invalid arguments: start date >= end date.");
    }

    private bool isValidParameters(DateOnly dataInicio, DateOnly dataFim){
        if( dataInicio >= dataFim )
            return false;

        return true;
    }

}
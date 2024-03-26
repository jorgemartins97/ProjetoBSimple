using System.Net;
using System.Reflection.Metadata;
using Domain.interfaces;

namespace Domain;

public class HolidayPeriod : IHolidayPeriod
{
	public DateOnly _startDate;
	public DateOnly _endDate;

	int _status;

	public HolidayPeriod(DateOnly startDate, DateOnly endDate)
	{
		if( startDate < endDate ) {
			_startDate = startDate;
			_endDate = endDate;
		}
		else
			throw new ArgumentException("invalid arguments: start date >= end date.");
	}

	public bool IsValidPeriod(DateOnly dataInicio, DateOnly dataFim){
		return dataInicio >= _startDate && dataFim <= _endDate;
	}

	public int CalcularNumeroDias(){
		var dias = _endDate.DayNumber - _startDate.DayNumber +1;
		return dias;
	}

	//Calcula o número de dias de sobreposição entre um período de férias e um período especificado
    public int CalculateTotalDays(DateOnly startDate, DateOnly endDate)
    {
        int totalDays = 0;
        if (startDate.CompareTo(_endDate) <= 0 && endDate.CompareTo(_startDate) >= 0)
        {
            // Calcula a sobreposição de dias entre o período de férias e o período especificado
            var overlapStart = startDate > _startDate ? startDate : _startDate;
            var overlapEnd = endDate < _endDate ? endDate : _endDate;
 
            // Calcula a diferença em dias
            totalDays = overlapEnd.DayNumber - overlapStart.DayNumber + 1;
        }
        return totalDays;
    }

}




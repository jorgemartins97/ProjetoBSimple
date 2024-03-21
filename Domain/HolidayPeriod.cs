using System.Net;
using System.Reflection.Metadata;
using Domain.interfaces;

namespace Domain;

public class HolidayPeriod : IHolidayPeriod
{
	DateOnly _startDate;
	DateOnly _endDate;

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


}




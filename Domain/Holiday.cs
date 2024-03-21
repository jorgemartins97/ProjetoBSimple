using Domain.interfaces;

namespace Domain;

public class Holiday : IHoliday
{
	private IColaborator _colaborator;

	private List<IHolidayPeriod> _holidayPeriods = new List<IHolidayPeriod>();

	public Holiday(IColaborator colab)
	{
		if(colab!=null)
			_colaborator = colab;
		else
			throw new ArgumentException("Invalid argument: colaborator must be non null");
	}

	public IHolidayPeriod addHolidayPeriod(IHolidayPeriodFactory hpFactory, DateOnly startDate, DateOnly endDate) {
        IHolidayPeriod holidayPeriod = hpFactory.NewHolidayPeriod(startDate, endDate);
        _holidayPeriods.Add(holidayPeriod);
        return holidayPeriod;
    }


	//Obter periodos de ferias de um colaborador dentro de um intervalo de datas
        public List<IHolidayPeriod> GetHolidayPeriodsForColaborator(IColaborator colaborator, DateOnly startDate, DateOnly endDate){
            var result = new List<IHolidayPeriod>();
            foreach ( var holidayP in _holidayPeriods) {
                if (holidayP.IsValidPeriod(startDate, endDate)){
					if( _colaborator.Equals(colaborator))
                	result.Add(holidayP);
                }
            }
            return result;
        }
}


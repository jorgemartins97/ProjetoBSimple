using Domain.interfaces;

namespace Domain;

public class Holiday : IHoliday
{
	private IColaborator _colaborator;

	private List<IHolidayPeriod> _holidayPeriods = new List<IHolidayPeriod>();

	public Holiday( IColaborator colab)
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

	 public bool HasColaborador(IColaborator colaborator){
        if(colaborator.Equals(_colaborator))
            return true;
        return false;
    }

	//Obter periodos de ferias de um colaborador dentro de um intervalo de datas
        public List<IHolidayPeriod> GetHolidayPeriodsForColaborator(DateOnly startDate, DateOnly endDate){
            var result = new List<IHolidayPeriod>();
            foreach ( var holidayP in _holidayPeriods) {
                if (holidayP.IsValidPeriod(startDate, endDate)){
                	result.Add(holidayP);
                }
            }
            return result;
        }

	public IColaborator GetColaboratorsWithHolidaysLongerThan(int days){
       IColaborator? colaboratorWithMoreThanXDays = null;
	
		foreach( var period in _holidayPeriods){
			int duration = period.CalcularNumeroDias();
			if(duration > days){
				colaboratorWithMoreThanXDays = _colaborator;
			}
		}
		if(colaboratorWithMoreThanXDays == null)
	   {
			throw new ArgumentException("Colaborator must be non-null");
	   }
		return colaboratorWithMoreThanXDays;	
	}

	public int getDaysColaboratorHolidayPeriod(IColaborator colaborator, DateOnly startDate, DateOnly endDate){
            int totalDays = 0;
			if( _colaborator.Equals(colaborator)){
				foreach(var holidayPeriod in _holidayPeriods)
				{
					totalDays += holidayPeriod.CalculateTotalDays(startDate, endDate);
				}
			}
			return totalDays;
            
    }
}



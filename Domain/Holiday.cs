namespace Domain;

public class Holiday
{
	private IColaborator _colaborator;

	private List<HolidayPeriod> _holidayPeriods = new List<HolidayPeriod>();

	public Holiday(IColaborator colab)
	{
		if(colab!=null)
			_colaborator = colab;
		else
			throw new ArgumentException("Invalid argument: colaborator must be non null");

		//_colaborator = colab ?? throw new ArgumentException("Invalid argument: colaborator must be non null");
	}

	// public HolidayPeriod addHolidayPeriod(DateOnly startDate, DateOnly endDate) {

	// 	new HolidayPeriod(startDate, endDate);


	// }

	public string getName() {
		return _colaborator.getName();
	}
}


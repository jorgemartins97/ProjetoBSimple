namespace Domain.interfaces
{
    public interface IHoliday
    {
        IHolidayPeriod addHolidayPeriod(IHolidayPeriodFactory hpFactory, DateOnly dataInicio, DateOnly dataFim);

    }
}
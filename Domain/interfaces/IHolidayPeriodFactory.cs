namespace Domain.interfaces
{
    public interface IHolidayPeriodFactory
    {
        IHolidayPeriod NewHolidayPeriod(DateOnly startDate, DateOnly endDate);
    }
}
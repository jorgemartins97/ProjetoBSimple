namespace Domain.interfaces
{
    public interface IHoliday
    {
        IHolidayPeriod addHolidayPeriod(IHolidayPeriodFactory hpFactory, DateOnly dataInicio, DateOnly dataFim);
        public List<IHolidayPeriod> GetHolidayPeriodsForColaborator(IColaborator colaborator, DateOnly startDate, DateOnly endDate);
        public int getDaysColaboratorHolidayPeriod(IColaborator colaborator, DateOnly startDate, DateOnly endDate);
    }
}
namespace Domain.interfaces
{
    public interface IHoliday
    {
        IHolidayPeriod addHolidayPeriod(IHolidayPeriodFactory hpFactory, DateOnly dataInicio, DateOnly dataFim);
        public List<IHolidayPeriod> GetHolidayPeriodsForColaborator( DateOnly startDate, DateOnly endDate);
        public int getDaysColaboratorHolidayPeriod(IColaborator colaborator, DateOnly startDate, DateOnly endDate);
        public IColaborator GetColaboratorsWithHolidaysLongerThan(int days);
        public bool HasColaborador(IColaborator colaborator);
    }
}
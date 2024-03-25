namespace Domain.interfaces{
    
    public interface IHolidays{
        public void AddHolidays(IHolidayFactory hfactory, IColaborator colaborator);
        public int CalculateColaboratorHolidays(IColaborator colaborator, IProjeto projeto, DateOnly startDate, DateOnly endDate);
        public List<IHolidayPeriod> GetHolidayPeriodsForColab(DateOnly startDate, DateOnly endDate, IColaborator colaborator);
        public List<IColaborator> GetColaboratorsWithHolidaysLongerThanXDays(int days);
        
    }
}
    
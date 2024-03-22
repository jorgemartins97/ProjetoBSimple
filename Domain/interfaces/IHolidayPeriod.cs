namespace Domain.interfaces{
    
    public interface IHolidayPeriod{
            public bool IsValidPeriod(DateOnly dataInicio, DateOnly dataFim);
            public int CalcularNumeroDias();
            public int CalculateTotalDays(DateOnly startDate, DateOnly endDate);
    }
}
    
namespace Domain.interfaces{
    
    public interface IHolidayPeriod{
            public bool IsValidPeriod(DateOnly dataInicio, DateOnly dataFim);
    }
}
    
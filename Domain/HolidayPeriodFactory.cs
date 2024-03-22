using Domain.interfaces;

namespace Domain;

public class HolidayPeriodFactory : IHolidayPeriodFactory{
        public IHolidayPeriod NewHolidayPeriod( DateOnly startDate, DateOnly endDate){
            return new HolidayPeriod(startDate, endDate);
    }

}
    

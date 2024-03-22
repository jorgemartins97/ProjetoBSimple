using System.Dynamic;
using Domain.interfaces;

namespace Domain;

    public class Holidays : IHolidays
    {
        private List<IHoliday> _holidays;

        public Holidays()
        {
            _holidays = new List<IHoliday>();
        }

        public void AddHoliday(IHoliday holiday){
            if(holiday == null)
            {
                throw new ArgumentNullException(nameof(holiday), "Holiday must be non-null");
            }
            _holidays.Add(holiday);
        }

       

    }




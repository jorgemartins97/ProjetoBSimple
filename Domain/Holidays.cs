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

    //    //US9: Como gestor de projeto, quero saber qual o número de dias de férias dum colaborador do projeto num dado período
    //     public int CalculateColaboratorHolidays(IColaborator colaborator, IProjeto projeto, DateOnly startDate, DateOnly endDate)
    //     {
    //         int totalDays = 0;
    //         if (projeto.isColaboratorInProject(associacao))
    //         {
    //             foreach (var holiday in _holidays)
    //                 totalDays += holiday.getDaysColaboratorHolidayPeriod(colaborator, startDate, endDate);
    //         }
    //         return totalDays;
    //     }
    }





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

        public void AddHolidays(IHolidayFactory hfactory, IColaborator colaborator)
        {
            var holidays = hfactory.NewHolidays(colaborator);
            _holidays.Add(holidays);

        }

//US8 Main
        public List<IHolidayPeriod> GetHolidayPeriodsForColab(DateOnly startDate, DateOnly endDate, IColaborator colaborator) {
        var result = new List<IHolidayPeriod>();
 
        var listHolidaysColaborador = getHolidaysColaborador(colaborator);
        foreach (var holiday in listHolidaysColaborador) {
            result.AddRange(holiday.GetHolidayPeriodsForColaborator(startDate,endDate));
        }
        return result;
    }
 
 
    private List<IHoliday> getHolidaysColaborador(IColaborator colaborator) {
       
        var result = new List<IHoliday>();
 
        if (_holidays != null) {
        // Itera sobre os feriados para encontrar aqueles que têm o colaborador.
        foreach (var holiday in _holidays) {
            if (holiday.HasColaborador(colaborator)) {
                result.Add(holiday);
            }
        }
    }
        return result;
    }

    // Método para obter colaboradores com férias superiores a X dias
    public List<IColaborator> GetColaboratorsWithHolidaysLongerThanXDays(int days) {
        var result = new List<IColaborator>();
        foreach (var holiday in _holidays) {
            IColaborator colaborator = holiday.GetColaboratorsWithHolidaysLongerThan(days);
            if(colaborator!=null) result.Add(colaborator);
        }
        return result;
    }

       //US9: Como gestor de projeto, quero saber qual o número de dias de férias dum colaborador do projeto num dado período
        public int CalculateColaboratorHolidays(IColaborator colaborator, IProjeto projeto, DateOnly startDate, DateOnly endDate)
        {
            int totalDays = 0;
            if (projeto.isColaboratorInProject(colaborator))
            {
                foreach (var holiday in _holidays)
                    totalDays += holiday.getDaysColaboratorHolidayPeriod(colaborator, startDate, endDate);
            }
            return totalDays;
        }
    }





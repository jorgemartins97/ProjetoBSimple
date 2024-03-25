using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain
{
    public class HolidayFactory : IHolidayFactory
    {
            public IHoliday NewHolidays(IColaborator colaborator)
        {
            return new Holiday(colaborator);
        }
    }
}
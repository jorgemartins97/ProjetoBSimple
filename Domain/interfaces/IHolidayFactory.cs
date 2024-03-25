using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IHolidayFactory
    {
         public IHoliday NewHolidays(IColaborator colaborator);
    }
}
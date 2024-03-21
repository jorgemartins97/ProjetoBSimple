using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IPeriodoFormacaoFactory
    {
        PeriodoFormacao NewPeriodoFormacao(DateOnly startDate, DateOnly endDate);
    }
}
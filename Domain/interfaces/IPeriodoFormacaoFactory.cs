using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.interfaces
{
    public interface IPeriodoFormacaoFactory
    {
        IPeriodoFormacao NewPeriodoFormacao(DateOnly startDate, DateOnly endDate);
    }
}
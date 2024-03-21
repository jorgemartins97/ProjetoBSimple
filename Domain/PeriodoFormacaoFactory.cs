using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class PeriodoFormacaoFactory
    {
        public PeriodoFormacao NewPeriodoFormacao( DateOnly startDate, DateOnly endDate) {
            return new PeriodoFormacao(startDate, endDate);
        }
    }
}
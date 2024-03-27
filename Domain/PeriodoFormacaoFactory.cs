using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain
{
    public class PeriodoFormacaoFactory : IPeriodoFormacaoFactory
    {
        public IPeriodoFormacao NewPeriodoFormacao( DateOnly dataIncio, DateOnly dataFim) {
            return new PeriodoFormacao(dataIncio, dataFim);
        }
    }
}
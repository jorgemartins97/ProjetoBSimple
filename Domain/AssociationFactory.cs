using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.interfaces;

namespace Domain
{
    public class AssociationFactory : IAssociationFactory
    {
        public IAssociacao NewAssociation(IColaborator colaborator)
        {
           return new Associacao(colaborator);
        }
    }
}
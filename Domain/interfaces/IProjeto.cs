namespace Domain.interfaces
{
    public interface IProjeto
    {
        public void addAssociacao(IAssociationFactory associationFactory, IColaborator colaborator);
        public bool isColaboratorInProject(IColaborator colaborator);

    }
}
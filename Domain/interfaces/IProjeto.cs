namespace Domain.interfaces
{
    public interface IProjeto
    {
        public void addAssociacao(Associacao associacao);
        public bool isColaboratorInProject(IColaborator colaborator);

    }
}
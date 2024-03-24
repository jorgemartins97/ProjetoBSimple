using Domain.interfaces;

namespace Domain;

public class Projeto : IProjeto{
    private string? _strName;
 
    private DateOnly? _startDate;
 
    private DateOnly? _endDate;
 
    private List<IAssociacao> _associations = new List<IAssociacao>();
	private static List<Projeto> _todosProjetos = new List<Projeto>();

	public Projeto(string strName, DateOnly startDate, DateOnly endDate){
		if( startDate < endDate && strName!=null &&
			strName.Length < 50 &&
			!string.IsNullOrWhiteSpace(strName) &&
			!ContainsAny(strName, ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"])) {
			this._startDate = startDate;
			this._endDate = endDate;
            this._strName = strName;
			_todosProjetos.Add(this);

		}
		else
			throw new ArgumentException("invalid arguments: start date >= end date or name is invalid.");
	}

    public Projeto()
    {
    }

    private bool ContainsAny(string stringToCheck, params string[] parameters){
		return parameters.Any(parameter => stringToCheck.Contains(parameter));
	}

    public List<IAssociacao> GetAssociacoes(){
        return _associations;
    }

    public void addAssociacao(Associacao associacao){
        _associations.Add(associacao);
    }

	// public List<IColaborator> GetColaborators(){
    //     var colaborators = new List<IColaborator>();
    //     foreach(IAssociacao associacao in _associations)
    //     {
    //         colaborators.Add(associacao.getColaborador());
    //     }
    //     return colaborators;

    public bool isColaboratorInProject(IAssociacao associacao){

		return _associations.Contains(associacao);
	}
    
}

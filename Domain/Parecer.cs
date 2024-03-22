using Domain.interfaces;

namespace Domain;

public class Parecer : IParecer
{
    private DateOnly _dataParecer;
    private string _parecer;
    private string _textoSuporte;
    private IColaborator _colaborator;

    public Parecer(DateOnly dataParecer, string parecer, string textoSuporte, IColaborator colab)
    {
        if( isValidParameters(dataParecer, parecer, textoSuporte, colab)){
            _dataParecer = dataParecer;
            _parecer = parecer;
            _textoSuporte = textoSuporte;
            //_colaborator = colab;          

        }
        else
            throw new ArgumentException("Invalid Argument");
    }

    private bool isValidParameters(DateOnly dataParecer, string parecer, string textoSuporte, IColaborator colab){
        if(colab == null || textoSuporte == null || string.IsNullOrWhiteSpace(textoSuporte) || (parecer!="favorável" && parecer!="dasfavorável" ))
        return false;

    return true;
    }

    // public string getName(){
    //     return _colaborator.getName();
    // }
    
}
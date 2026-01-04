//// Cod creat ca exemplu pt Unit Testing

namespace SistemRezervari.CORE.BookingLogic;

public class Testare
{
    private IPersoana _persoana;

    public Testare(IPersoana persoana)
    {
        _persoana = persoana;
    }

    public bool VarstaAdmisa()
    {
        if (_persoana.GetVarsta() < 18)
            return false;
        if (_persoana.GetVarsta() > 99)
            throw new Exception("Varsta imposibila!");
        return true;
    }
}
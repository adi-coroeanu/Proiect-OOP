// Cod creat ca exemplu pt Unit Testing

namespace App;

public class PersoanaTest : IPersoana
{
    public string Nume { get; init; }
    private int _varsta;

    public int GetVarsta()
    {
        return _varsta;
    }

    public PersoanaTest(string nume, int varsta)
    {
        Nume = nume;
        _varsta = varsta;
    }
}
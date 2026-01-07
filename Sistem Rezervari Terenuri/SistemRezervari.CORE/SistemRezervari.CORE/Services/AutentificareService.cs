using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class AutentificareService : IAutentificareService
{
    private readonly List<Utilizator> _listaUtilizatori;

    public AutentificareService(IFileRepository repository)
    {
        _listaUtilizatori = repository.IncarcaUtilizatori();
    }

    public Utilizator? Login(string username, string parola)
    {
        Utilizator? userGasit = _listaUtilizatori.Find(u => u.Username == username && u.Parola == parola);

        return userGasit;
    }
}
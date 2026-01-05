using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class AutentificareService : IAutentificareService
{
    private List<Utilizator> _listaUtilizatori;

    public AutentificareService(List<Utilizator> listaUtilizatori)
    {
        _listaUtilizatori = listaUtilizatori;
    }

    public Utilizator? Login(string username, string parola)
    {
        Utilizator? userGasit = _listaUtilizatori.Find(u => u.Username == username && u.Parola == parola);

        return userGasit;
    }
}
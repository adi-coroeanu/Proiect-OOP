using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class AutentificareService : IAutentificareService
{
    private readonly IFileRepository _repository;
    private readonly List<Utilizator> _listaUtilizatori;

    public AutentificareService(IFileRepository repository)
    {
        _repository = repository;
        _listaUtilizatori = _repository.IncarcaUtilizatori();
    }

    public Utilizator? Login(string username, string parola)
    {
        Utilizator? userGasit = _listaUtilizatori.Find(u => u.Username == username && u.Parola == parola);

        return userGasit;
    }
    public void Signup(string username, string parola, string parolaConfirmare)
    {
        if (parola != parolaConfirmare)
        {
            throw new ArgumentException("Parolele nu se potrivesc.");
        }

        if (_listaUtilizatori.Any(u => u.Username == username))
        {
            throw new ArgumentException("Numele de utilizator este deja folosit.");
        }

        var noulUtilizator = new Utilizator(Guid.NewGuid(), username, parola, "Client");
        _listaUtilizatori.Add(noulUtilizator);
        
        _repository.SalveazaUtilizatori(_listaUtilizatori);
    }
}
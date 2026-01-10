using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class AutentificareService : IAutentificareService
{
    private readonly IFileRepository _repository;
    private readonly List<Utilizator> _listaUtilizatori;
    private readonly ILogger<AutentificareService> _logger;

    public AutentificareService(IFileRepository repository, ILogger<AutentificareService> logger)
    {
        _repository = repository;
        _listaUtilizatori = _repository.IncarcaUtilizatori();
        _logger = logger;
        
        _logger.LogInformation("AutentificareService initialized successfully.");
    }

    public Utilizator? Login(string username, string parola)
    {
        Utilizator? userGasit = _listaUtilizatori.Find(u => u.Username == username && u.Parola == parola);

        if (userGasit == null)
        {
            _logger.LogWarning("Login failed for username: {Username}", username);
        }
        else
        {
            _logger.LogInformation("User {Username} logged in successfully.", username);
        }
        
        return userGasit;
    }
    public bool Signup(string username, string parola, string parolaConfirmare)
    {
        if (parola != parolaConfirmare)
        {
            _logger.LogWarning("Signup failed for username: {Username} - passwords do not match.", username);
            return false;
        }

        if (_listaUtilizatori.Any(u => u.Username == username))
        {
            _logger.LogWarning("Signup failed for username: {Username} - username already exists.", username);
            return false;
        }

        var noulUtilizator = new Utilizator(Guid.NewGuid(), username, parola, "Client");
        _listaUtilizatori.Add(noulUtilizator);
        
        _repository.SalveazaUtilizatori(_listaUtilizatori);

        return true;
    }
}
namespace SistemRezervari.CORE.Interfaces;

using SistemRezervari.CORE.Entities;

public interface IAutentificareService
{
    public Utilizator? Login(string username, string parola);
    
    // true - signup reusit, false - signup esuat
    public bool Signup(string username, string parola, string parolaConfirmare);
}
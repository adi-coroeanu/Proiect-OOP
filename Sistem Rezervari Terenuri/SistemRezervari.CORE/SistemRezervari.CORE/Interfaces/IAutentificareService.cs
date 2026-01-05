namespace SistemRezervari.CORE.Interfaces;

using SistemRezervari.CORE.Entities;

public interface IAutentificareService
{
    public Utilizator? Login(string username, string parola);
}
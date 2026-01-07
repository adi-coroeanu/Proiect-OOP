using SistemRezervari.CORE.Entities;

namespace SistemRezervari.UI.MocksUI;
using CORE.Interfaces;

public class MockLogIn : IAutentificareService
{
    public Utilizator? Login(string username, string parola)
    {
        if (username == "admin" && parola == "admin")
        {
            return new Utilizator(Guid.NewGuid(), "admin", "admin", "Administrator");
        }
        
        if (username == "client" && parola == "client")
        {
            return new Utilizator(Guid.NewGuid(), "client", "client", "Client");
        }

        // Dacă datele sunt greșite
        return null;
    }
}
namespace SistemRezervari.CORE.Entities;

public record Utilizator(
    Guid Id,
    string Username,
    string Parola,       // În realitate ar fi un hash, aici e simplificat
    string Rol           // "Admin" sau "Client"
);
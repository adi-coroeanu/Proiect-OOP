namespace SistemRezervari.CORE.Entities;

public record Teren(
    Guid Id,
    string Nume,
    string TipSport,
    int Capacitate,
    bool EsteActiv
);
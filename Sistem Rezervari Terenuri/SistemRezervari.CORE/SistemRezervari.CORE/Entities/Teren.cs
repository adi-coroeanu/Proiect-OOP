namespace SistemRezervari.CORE.Entities;

public record Teren(
    Guid Id,
    string Nume,
    string TipSport,
    int Capacitate,
    string program_de_functionare,
    string intervale_indisponibile,
    bool EsteActiv
    
);
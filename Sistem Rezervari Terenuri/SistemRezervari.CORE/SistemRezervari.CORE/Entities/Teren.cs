namespace SistemRezervari.CORE.Entities;

public record Teren(
    Guid Id,
    string Nume,
    string TipSport,
    int Capacitate,
    string program_de_functionare, // Format acceptat: "10:00-22:00"
    string intervale_indisponibile
    
);
namespace SistemRezervari.CORE.Entities;

public record Teren(
    Guid Id,
    string Nume,
    string TipSport,
    int Capacitate,
    string program_de_functionare, // Format acceptat: "10:00-22:00"
    string intervale_indisponibile, // Format acceptat: "12:00-13:00, 18:00-19:00" sau "none"
    int nr_max_rezervari,
    int durata_standard
    
);
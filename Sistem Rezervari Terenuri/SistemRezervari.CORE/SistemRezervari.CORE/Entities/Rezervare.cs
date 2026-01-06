namespace SistemRezervari.CORE.Entities;

public record Rezervare(
    Guid Id,
    Guid TerenId,        
    Guid UtilizatorId,   
    DateTime DataInceput,
    DateTime DataSfarsit,
    int nr_max_rezervare
);
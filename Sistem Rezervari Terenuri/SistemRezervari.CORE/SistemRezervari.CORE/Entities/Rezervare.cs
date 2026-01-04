namespace SistemRezervari.CORE.Entities;

public record Rezervare(
    Guid Id,
    Guid TerenId,        // Legătura cu terenul
    Guid UtilizatorId,   // Cine a făcut rezervarea
    DateTime DataInceput,// ex: 2023-10-10 14:00
    DateTime DataSfarsit,// ex: 2023-10-10 16:00
    bool EsteAnulata     // Dacă clientul a renunțat la ea
);
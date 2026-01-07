using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IBookingService
{
    public List<Teren> SearchField(string sportType, DateTime startTime, DateTime endTime);
    public Teren? ViewInfoField(Guid fieldId);
    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate, DateTime endDate); // Adaugare reguli
    public List<Rezervare>? GetUserReservations(Guid clientId);
}
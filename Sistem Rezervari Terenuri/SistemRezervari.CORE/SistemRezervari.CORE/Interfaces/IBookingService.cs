using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IBookingService
{
    public List<Teren>? SearchFieldsBySport(string sportType);
    public List<Teren>? SearchFieldsByDate(string date);
    public List<string>? GetAvailableSlots(Guid fieldId, string date);
    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate);
    public void DeleteReservation(Guid reservationId);
    public List<Rezervare>? GetUserReservations(Guid clientId);
}
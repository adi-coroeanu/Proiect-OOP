using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IBookingService
{
    public List<Teren>? SearchFieldsBySport(string sportType);
    public List<Teren>? SearchFieldsByDate(string date);
    public Teren? ViewInfoField(Guid fieldId);
    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate);
    public List<Rezervare>? GetUserReservations(Guid clientId);
}
using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IBookingService
{
    public List<Teren> SearchField(string tipSport, DateTime oraStart, DateTime oraFinal);
    public Teren ViewInfoField(Guid terenId);
    public void MakeReservation(Guid fieldId, Guid userId, DateTime dateStart, DateTime dateEnd); // Adaugare reguli
    public List<Rezervare> GetUserReservations(Guid clientId);
}
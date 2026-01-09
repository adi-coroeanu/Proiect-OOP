using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IReservationAdministration
{
    public void RemoveReservation(Guid reservationId);
    public void ModifyReservation(Guid reservationId, string from);
    public List<Rezervare> GetAllReservations(Guid terenId);
}
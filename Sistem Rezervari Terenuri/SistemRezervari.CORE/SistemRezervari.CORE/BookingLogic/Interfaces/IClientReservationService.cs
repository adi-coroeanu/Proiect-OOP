namespace SistemRezervari.CORE.BookingLogic.Interfaces;

public interface IClientReservationService
{
    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate);
}
using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.BookingLogic.Interfaces;

public interface IClientDashboardService
{
    public List<Rezervare> GetUserReservations(Guid clientId);
}
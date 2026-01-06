using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Services;

// Vede lista de rezervari(Trecut|Viitor)
public class ClientDashboardService : IClientDashboardService
{
    private ReservationRepository _reservationRepo;
    public ClientDashboardService(ReservationRepository reservationRepo)
    {
        _reservationRepo = reservationRepo;
    }
    public List<Rezervare> GetUserReservations(Guid clientId)
    {
        throw new NotImplementedException();
    }
}
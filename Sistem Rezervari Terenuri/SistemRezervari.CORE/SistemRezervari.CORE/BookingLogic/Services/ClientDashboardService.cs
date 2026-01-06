using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Vede lista de rezervari(Trecut|Viitor)
public class ClientDashboardService : IClientDashboardService
{
    private IRepository<Rezervare> _reservationRepo;
    public ClientDashboardService(IRepository<Rezervare> reservationRepo)
    {
        _reservationRepo = reservationRepo;
    }
    public List<Rezervare> GetUserReservations(Guid clientId)
    {
        var userReservations = _reservationRepo.GetCopyAll()
            .Where(r => r.UtilizatorId == clientId)
            .OrderByDescending(r => r.DataInceput);

        return userReservations.ToList(); 
    }
}
using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Vede lista de rezervari(Trecut|Viitor)
public class ClientDashboardService : IClientDashboardService
{
    private readonly List<Rezervare> _reservationList;
    public ClientDashboardService(IFileRepository repository)
    {
        _reservationList = repository.IncarcaRezervari();
    }
    public List<Rezervare>? GetUserReservations(Guid clientId)
    {
        var userReservations = _reservationList
            .Where(r => r.UtilizatorId == clientId)
            .OrderByDescending(r => r.DataInceput).ToList();
        
        return userReservations.Count == 0? null : userReservations;
    }
}
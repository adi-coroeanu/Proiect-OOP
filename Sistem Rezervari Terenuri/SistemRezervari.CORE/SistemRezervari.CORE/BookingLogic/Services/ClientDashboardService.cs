using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Vede lista de rezervari(Trecut|Viitor)
public class ClientDashboardService : IClientDashboardService
{
    private readonly List<Rezervare> _reservationList;
    private readonly ILogger _logger;
    public ClientDashboardService(IFileRepository repository, ILogger logger)
    {
        _reservationList = repository.IncarcaRezervari();
        _logger = logger;
    }
    public List<Rezervare>? GetUserReservations(Guid clientId)
    {
        var userReservations = _reservationList
            .Where(r => r.UtilizatorId == clientId)
            .OrderByDescending(r => r.DataInceput).ToList();
        
        _logger.LogInformation("Fetched {Count} reservations for user {UserId}", userReservations.Count, clientId);
        
        return userReservations.Count == 0? null : userReservations;
    }
}
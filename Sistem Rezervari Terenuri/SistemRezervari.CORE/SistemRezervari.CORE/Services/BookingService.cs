using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.BookingLogic.Services;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class BookingService : IBookingService
{
    private readonly IFieldCatalogService _fieldCatalogService;
    private readonly IClientReservationService _clientReservationService;
    private readonly IClientDashboardService _clientDashboardService;
    private readonly ILogger _logger;
    
    public BookingService(IFileRepository repository, ILogger logger)
    {
        _fieldCatalogService = new FieldCatalogService(repository);
        _clientReservationService = new ClientReservationService(repository);
        _clientDashboardService = new ClientDashboardService(repository);
        _logger = logger;
    }

    public List<Teren>? SearchFieldsBySport(string sportType)
    {
        return _fieldCatalogService.SearchFieldsBySport(sportType);
    }
    
    public List<Teren>? SearchFieldsByDate(string date)
    {
        return _fieldCatalogService.SearchFieldsByDate(date);
    }

    public Teren? ViewInfoField(Guid fieldId)
    {
        return _fieldCatalogService.ViewInfoField(fieldId);
    }
    

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate)
    {
        throw new NotImplementedException();
    }

    public List<Rezervare>? GetUserReservations(Guid clientId)
    {
        return _clientDashboardService.GetUserReservations(clientId);
    }

}
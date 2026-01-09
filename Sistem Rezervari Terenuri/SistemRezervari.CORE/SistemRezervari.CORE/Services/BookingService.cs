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
    
    public BookingService(IFileRepository repository, ILogger logger)
    {
 
        _fieldCatalogService = new FieldCatalogService(repository, logger);
        _clientReservationService = new ClientReservationService(repository, logger);
        _clientDashboardService = new ClientDashboardService(repository, logger);
            
        logger.LogInformation("FieldCatalogService initialized successfully.");
    }

    public List<Teren>? SearchFieldsBySport(string sportType)
    {
        return _fieldCatalogService.SearchFieldsBySport(sportType);
    }
    
    public List<Teren>? SearchFieldsByDate(string date) // Ca metoda sa functioneze trebuie inainte folosita SearchFieldBySport
    {
        return _fieldCatalogService.SearchFieldsByDate(date);
    }

    public List<string>? GetAvailableSlots(Guid fieldId, string date)
    {
        return _fieldCatalogService.GetAvailableSlots(fieldId, date);
    }
    

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate)
    {
        _clientReservationService.MakeReservation(fieldId, userId, startDate);
    }

    public List<Rezervare>? GetUserReservations(Guid clientId)
    {
        return _clientDashboardService.GetUserReservations(clientId);
    }

}
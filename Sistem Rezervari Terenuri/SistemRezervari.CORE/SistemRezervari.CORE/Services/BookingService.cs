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
    
    public BookingService(IFileRepository repository)
    {
        try
        {
            _fieldCatalogService = new FieldCatalogService(repository);
            _clientReservationService = new ClientReservationService(repository);
            _clientDashboardService = new ClientDashboardService(repository);
        }
        catch (Exception e)
        {
            throw new Exception("Eroare la initializarea serviciului pentru clienti.", e); // Posibila modificare (Logger)
        }
    }
    
    public List<Teren> SearchField(string sportType, DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }

    public Teren? ViewInfoField(Guid fieldId)
    {
        return _fieldCatalogService.ViewInfoField(fieldId);
    }
    

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public List<Rezervare>? GetUserReservations(Guid clientId)
    {
        return _clientDashboardService.GetUserReservations(clientId);
    }

}
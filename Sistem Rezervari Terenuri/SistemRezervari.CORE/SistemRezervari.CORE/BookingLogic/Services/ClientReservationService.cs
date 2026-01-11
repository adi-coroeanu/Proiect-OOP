using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Creeaza rezervari noi
public class ClientReservationService : IClientReservationService
{
    private readonly IFileRepository _repository;
    private readonly List<Rezervare> _reservationList;
    private readonly List<Teren> _fieldList;
    private readonly ILogger<ClientReservationService> _logger;

    public ClientReservationService(IFileRepository repository, ILogger<ClientReservationService> logger)
    {
        _repository = repository;
        _reservationList = _repository.IncarcaRezervari();
        _fieldList = _repository.IncarcaTerenuri();
        _logger = logger;
    }

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate)
    {
        int durataStandard = _fieldList.Find(f => f.Id == fieldId)?.durata_standard ?? 60;
        DateTime endDate = startDate.AddMinutes(durataStandard);
        
        var newReservation = new Rezervare
        (
            Guid.NewGuid(),
            fieldId,
            userId,
            startDate,
            endDate
        );
        
        _reservationList.Add(newReservation);
        _repository.SalveazaRezervari(_reservationList);
        
        _logger.LogInformation("New reservation created: {ReservationId} for user {UserId} on field {FieldId} from {StartDate} to {EndDate}",
            newReservation.Id, userId, fieldId, startDate, endDate);
    }

    public void DeleteReservation(Guid reservationId)
    {
        var reservationToRemove = _reservationList.Find(r => r.Id == reservationId);
        if (reservationToRemove != null)
        {
            _reservationList.Remove(reservationToRemove);
            _repository.SalveazaRezervari(_reservationList);
            _logger.LogInformation("Reservation {ReservationId} deleted successfully.", reservationId);
        }
        else
        {
            _logger.LogWarning("Reservation {ReservationId} not found. Deletion failed.", reservationId);
        }
    }
}

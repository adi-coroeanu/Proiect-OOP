using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Creeaza rezervari noi
public class ClientReservationService : IClientReservationService
{
    private readonly IFileRepository _repository;
    private readonly List<Rezervare> _reservationList;

    public ClientReservationService(IFileRepository repository)
    {
        _repository = repository;
        _reservationList = _repository.IncarcaRezervari();
    }

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate, DateTime endDate)
    {
        DateTime currentTime = DateTime.Now;

        if (startDate < currentTime || endDate <= startDate)
        {
            throw new Exception("Intervalul de timp pentru rezervare este invalid.");
        }

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
    }
}

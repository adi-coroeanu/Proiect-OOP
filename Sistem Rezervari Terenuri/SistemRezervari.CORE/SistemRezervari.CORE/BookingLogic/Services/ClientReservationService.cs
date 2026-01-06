using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Creeaza rezervari noi
public class ClientReservationService : IClientReservationService
{
    private IRepository<Rezervare> _reservationRepo;

    public ClientReservationService(IRepository<Rezervare> reservationRepo)
    {
        _reservationRepo = reservationRepo;
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
            endDate,
            0,   // Problema aici
            0
        );
        
        _reservationRepo.Add(newReservation);
    }
}

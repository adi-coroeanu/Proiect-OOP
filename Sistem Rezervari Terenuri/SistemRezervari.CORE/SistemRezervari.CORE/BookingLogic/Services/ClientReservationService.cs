using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Data;

namespace SistemRezervari.CORE.Services;

// Creeaza rezervari noi
public class ClientReservationService : IClientReservationService
{
    private ReservationRepository _reservationRepo;
    
    public ClientReservationService(ReservationRepository reservationRepo)
    {
        _reservationRepo = reservationRepo;
    }

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate, DateTime endDate)
    {
        
    }
    
}
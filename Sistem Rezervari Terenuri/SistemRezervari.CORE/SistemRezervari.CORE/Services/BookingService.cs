using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class BookingService : IBookingService
{
    private ReservationRepository _reservationRepository;
    private FieldRepository _fieldRepository;
    private UserRepository _userRepository;
    public BookingService(ReservationRepository reservationRepo, FieldRepository fieldRepo, UserRepository userRepo)
    {
        try
        {
            _reservationRepository = reservationRepo;
            _fieldRepository = fieldRepo;
            _userRepository = userRepo;
        }
        catch (Exception e)
        {
            throw new Exception("Eroare la initializarea serviciului pentru clienti.", e); // Posibila modificare (Logger)
        }
    }

    // Initializarea celor 3 clase componente
    private void InitBookingService()
    {
        throw new NotImplementedException();
    }
    
    public List<Teren> SearchField(string sportType, DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }

    public Teren ViewInfoField(Guid fieldId)
    {
        throw new NotImplementedException();
    }
    

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public List<Rezervare> GetUserReservations(Guid clientId)
    {
        throw new NotImplementedException();
    }
}
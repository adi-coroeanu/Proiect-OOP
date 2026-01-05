using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class BookingService : IBookingService
{
    private List<Teren> _fieldsList;
    private List<Rezervare> _reservationsList;
    
    public BookingService(List<Teren> fieldsList, List<Rezervare> reservationsList)
    {
        _fieldsList = fieldsList;
        _reservationsList = reservationsList;
    }
    public List<Teren> SearchField(string tipSport, DateTime oraStart, DateTime oraFinal)
    {
        throw new NotImplementedException();
    }

    public Teren ViewInfoField(Guid terenId)
    {
        throw new NotImplementedException();
    }
    

    public void MakeReservation(Guid fieldId, Guid userId, DateTime dateStart, DateTime dateEnd)
    {
        var idReservation = Guid.NewGuid();

        var newReservation = new Rezervare(idReservation, fieldId, userId, dateStart, dateEnd, false);
    }

    public List<Rezervare> GetUserReservations(Guid clientId)
    {
        throw new NotImplementedException();
        // Aici logica anulare
    }
}
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class BookingService : IBookingService
{
    
    
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
        throw new NotImplementedException();
    }

    public List<Rezervare> GetUserReservations(Guid clientId)
    {
        throw new NotImplementedException();
    }
}
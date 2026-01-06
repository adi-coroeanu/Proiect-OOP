using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class ReservationAdministration : IReservationAdministration
{
    private ReservationRepository _reservationRepository;
    private List<Rezervare> _reservations;
    public ReservationAdministration(ReservationRepository  reservationRepository)
    {
       _reservationRepository = reservationRepository; 
       _reservations = _reservationRepository.GetCopyAll();
    }

    #region Public Methods
    public void RemoveReservation(Guid reservationId)
    {
        throw new NotImplementedException();
    }

    public void ModifyReservation(Guid reservationId, DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }

    
    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        return _reservations;
    }
   #endregion
}
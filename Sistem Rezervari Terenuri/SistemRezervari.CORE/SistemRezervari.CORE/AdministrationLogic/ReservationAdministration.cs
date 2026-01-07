using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class ReservationAdministration : IReservationAdministration
{
    private ReservationRepository _reservationRepository;
    private List<Rezervare> _reservations;
    private List<Rezervare> _reservations_with_specific_fieldID = new List<Rezervare>();
    
    public ReservationAdministration(ReservationRepository  reservationRepository)
    {
       _reservationRepository = reservationRepository; 
       _reservations = _reservationRepository.GetCopyAll();
    }
    

    #region Private Methods
    private void _RemoveReservation(Guid reservationId)
    {
        for (int i = 0; i < _reservations.Count; i++)
        {
            if (_reservations[i].Id == reservationId)
                _reservations.RemoveAt(i);
        }
    }

    private void _GetAllReservations(Guid terenId)
    {
        foreach (var reservation in _reservations)
            if(reservation.TerenId == terenId)
                _reservations_with_specific_fieldID.Add(reservation);
    }

    private void _ModifyReservation(Guid reservationId, DateTime from, DateTime to)
    {
        for(int i=0; i<_reservations.Count; i++)
        {
            if (_reservations[i].Id == reservationId)
            {
                var new_reservation = _reservations[i] with
                {
                    DataInceput = from,
                    DataSfarsit = to
                };
                _reservations[i] =  new_reservation;
            }
        }
    }
    #endregion
    
    #region Public Methods
    public void RemoveReservation(Guid reservationId)
    {
        _RemoveReservation(reservationId);
        _reservationRepository.ModifyList(_reservations);
    }

    public void ModifyReservation(Guid reservationId, DateTime from, DateTime to)
    {
        _ModifyReservation(reservationId, from, to);
        _reservationRepository.ModifyList(_reservations);
    }

    
    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        _GetAllReservations(terenId);
        return _reservations_with_specific_fieldID;
    }
   #endregion
}
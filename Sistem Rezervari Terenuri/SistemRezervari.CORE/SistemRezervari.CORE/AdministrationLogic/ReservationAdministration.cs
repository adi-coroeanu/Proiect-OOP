using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class ReservationAdministration : IReservationAdministration
{
   
    private IFileRepository _fileRepository;
    private List<Rezervare> _reservations;
    
    
    public ReservationAdministration(IFileRepository fileRepository)
    {
       _fileRepository = fileRepository;
       _reservations = _fileRepository.IncarcaRezervari();
       
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
        _fileRepository.SalveazaRezervari(_reservations);
    }

    public void ModifyReservation(Guid reservationId, DateTime from, DateTime to)
    {
        _ModifyReservation(reservationId, from, to);
        _fileRepository.SalveazaRezervari(_reservations);
    }

    
    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        return _reservations.Where(r => r.TerenId == terenId).ToList();
    }
   #endregion
}
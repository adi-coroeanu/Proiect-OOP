using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class ReservationAdministration : IReservationAdministration
{
   
    private IFileRepository _fileRepository;
    private List<Rezervare> _reservations;
    private List<Teren> _fields;
    
    
    public ReservationAdministration(IFileRepository fileRepository)
    {
       _fileRepository = fileRepository;
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
    

    private void _ModifyReservation(Guid reservationId, DateTime from)
    {
        for(int i=0; i<_reservations.Count; i++)
        {
            if (_reservations[i].Id == reservationId)
            {
                var new_reservation = _reservations[i] with
                {
                    DataInceput = from,
                    DataSfarsit = from.AddHours((int)_fields[i].durata_standard/60)
                };
                _reservations[i] =  new_reservation;
            }
        }
    }
    #endregion
    
    #region Public Methods
    public void RemoveReservation(Guid reservationId)
    {
        _reservations = _fileRepository.IncarcaRezervari();
        _RemoveReservation(reservationId);
        _fileRepository.SalveazaRezervari(_reservations);
    }

    public void ModifyReservation(Guid reservationId, DateTime from)
    {
        _fields = _fileRepository.IncarcaTerenuri();
        _reservations = _fileRepository.IncarcaRezervari();
        _ModifyReservation(reservationId, from);
        _fileRepository.SalveazaRezervari(_reservations);
    }

    
    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        _reservations = _fileRepository.IncarcaRezervari();
        return _reservations.Where(r => r.TerenId == terenId).ToList();
    }
   #endregion
}
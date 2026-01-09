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
    

    private void _ModifyReservation(Guid reservationId, string from)
    {
        List<string> program = from.Split('/').ToList();
        int year = int.Parse(program[2]);
        int month = int.Parse(program[1]);
        int day = int.Parse(program[0]);
        if (month < 1 || month > 12) 
        {
            throw new InvalidDataException("Month must be between 1 and 12");
        }

        if (day < 1 || day > 31) 
        {
            throw new InvalidDataException("Day must be between 1 and 31");
        }
        
        if (day > DateTime.DaysInMonth(year, month))
        {
            throw new InvalidDataException($"Month {month} from year {year} does not have {day} days!");
        }
        
        DateTime time = new DateTime(int.Parse(program[2]), int.Parse(program[1]), int.Parse(program[0]));
        for(int i=0; i<_reservations.Count; i++)
        {
            Teren field_as = _fields.FirstOrDefault(t => t.Id == _reservations[i].TerenId);
            if (_reservations[i].Id == reservationId)
            {
                var new_reservation = _reservations[i] with
                {
                    DataInceput = time,
                    DataSfarsit = time.AddHours((int)field_as.durata_standard/60)
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

    public void ModifyReservation(Guid reservationId, string from)
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
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
        List<string> date_and_hour = from.Split(" ").ToList();
        List<string> date =  date_and_hour[0].Split("/").ToList();
        List<string> hour  = date_and_hour[1].Split(":").ToList();
        int year = int.Parse(date[2]);
        int month = int.Parse(date[1]);
        int day = int.Parse(date[0]);
        int hours = int.Parse(hour[0]);
        int minutes = int.Parse(hour[1]);
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

        if (hours > 24 && hours < 0)
        {
            throw new InvalidDataException("Hours must be between 0 and 24");
        }

        if (minutes > 59 && minutes < 0)
        {
            throw new InvalidDataException("Minutes must be between 0 and 59");
        }
        DateTime time = new DateTime(year, month, day, hours, minutes,0);
        for(int i=0; i<_reservations.Count; i++)
        {
            Teren field_as = _fields.FirstOrDefault(t => t.Id == _reservations[i].TerenId);
            if (_reservations[i].Id == reservationId)
            {
                var new_reservation = _reservations[i] with
                {
                    DataInceput = time,
                    DataSfarsit = time.AddMinutes(field_as.durata_standard)
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
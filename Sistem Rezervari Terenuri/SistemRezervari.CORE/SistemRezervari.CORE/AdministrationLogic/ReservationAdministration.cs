using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class ReservationAdministration : IReservationAdministration
{
    private List<Rezervare> _reservations;

    public ReservationAdministration(List<Rezervare> reservations)
    {
        _reservations = reservations;
    }

    public Rezervare ModifyStandardLength(int Length,Rezervare reservation)
    {
        var new_reservation = reservation with {durata_standard = Length};
        return new_reservation;
    }

    public Rezervare Modify_begin_end_date(DateTime begin_date, DateTime end_date, Rezervare reservation)
    {
        var new_reservation = reservation with {DataInceput = begin_date, DataSfarsit = end_date};
        return new_reservation;
    }

    public Rezervare Modify_nr(int nr, Rezervare reservation)
    {
        var new_reservation = reservation with {nr_max_rezervare = nr};
        return new_reservation;
    }
    
    
    
    
    
    public void ModifyReservation()
    {
        throw new NotImplementedException();
    }

    public void VisualizeRezervations()
    {
        throw new NotImplementedException();
    }
}
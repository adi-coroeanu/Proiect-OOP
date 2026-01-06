using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.AdministrationLogic;

public class ReservationAdministration
{
    private List<Rezervare> _reservations;
    
    public ReservationAdministration(List<Rezervare> reservations)
    {
        _reservations = reservations;
    }
}
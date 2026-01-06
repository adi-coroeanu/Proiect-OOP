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

    public void ModifyReservation()
    {
        throw new NotImplementedException();
    }

    public void VisualizeRezervations()
    {
        throw new NotImplementedException();
    }
}
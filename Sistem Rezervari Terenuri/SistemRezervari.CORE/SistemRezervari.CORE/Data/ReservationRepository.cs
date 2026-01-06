using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Data;

public class ReservationRepository : IRepository<Rezervare>
{
    private List<Rezervare> _reservations;
    
    public ReservationRepository(List<Rezervare> reservations)
    {
        _reservations = reservations;
    }
    
    public void Add(Rezervare value)
    {
        _reservations.Add(value);
    }
    
    public List<Rezervare> GetCopyAll()
    {
        return new List<Rezervare>(_reservations);
    }

    public void ModifyList(List<Rezervare> value)
    {
        _reservations = value;
    }
}
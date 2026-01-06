using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Data;

public class ReservationRepository
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
}
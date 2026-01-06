using SistemRezervari.CORE.AdministrationLogic;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class AdministrareService
{
    private List<Rezervare> _reservations;
    private List<Teren> _fields;
    private ReservationRepository _reservationRepository;
    private FieldRepository _fieldRepository;
    private FieldAdministration _fieldAdministration;
    private ReservationAdministration _reservationAdministration;
    
    public AdministrareService()
    {
        _reservations = new List<Rezervare>();
        _reservationRepository = new ReservationRepository(_reservations);

        _fields = new List<Teren>();
        _fieldRepository = new FieldRepository(_fields);                //astea trebuie neaparat primite prin constructor pentru a face
                                                                        // aceeasi referinta!!
        
        _fieldAdministration = new FieldAdministration(_fieldRepository);
        _reservationAdministration = new ReservationAdministration(_reservationRepository);
    }


}
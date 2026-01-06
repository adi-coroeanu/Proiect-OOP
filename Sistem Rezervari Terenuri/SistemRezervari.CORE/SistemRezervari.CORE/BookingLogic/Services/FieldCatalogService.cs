using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Searcher (Cauta terenuri libere pe baza criterilor)
public class FieldCatalogService : IFieldCatalogService
{
    private IRepository<Rezervare> _reservationRepo;
    private IRepository<Teren> _fieldRepo;
    public FieldCatalogService(IRepository<Rezervare> reservationRepo, IRepository<Teren> fieldRepo)
    {
        _reservationRepo = reservationRepo;
        _fieldRepo = fieldRepo;
    }

    public List<Teren> SearchField(string sportType, DateTime startTime, DateTime endTime)
    {
        // var eligibleFields = _fieldRepo.GetCopyAll()
        //     .Where(f => f.TipSport == sportType).Where(f => f.).ToList(); // Filtreaza dupa tip sport

        throw new NotImplementedException();

    }

    public Teren? ViewInfoField(Guid fieldId)
    {
        var field = _fieldRepo.GetCopyAll().Find(f => f.Id == fieldId);
        
        return field; // Returneaza null daca nu exista
    }
}
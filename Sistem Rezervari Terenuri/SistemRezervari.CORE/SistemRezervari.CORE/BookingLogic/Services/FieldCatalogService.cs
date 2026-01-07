using SistemRezervari.CORE.BookingLogic.Interfaces;

using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Searcher (Cauta terenuri libere pe baza criterilor)
public class FieldCatalogService : IFieldCatalogService
{
    // private readonly IFileRepository _repository;
    private readonly List<Rezervare> _reservationList;
    private readonly List<Teren> _fieldList;
    public FieldCatalogService(IFileRepository repository)
    {
        _reservationList = repository.IncarcaRezervari();
        _fieldList = repository.IncarcaTerenuri();
    }

    public List<Teren> SearchField(string sportType, DateTime startTime, DateTime endTime)
    {
        // var eligibleFields = _fieldRepo.GetCopyAll()
        //     .Where(f => f.TipSport == sportType).Where(f => f.).ToList(); // Filtreaza dupa tip sport

        throw new NotImplementedException();

    }

    public Teren? ViewInfoField(Guid fieldId)
    {
        var field = _fieldList.Find(f => f.Id == fieldId);
        
        return field; // Returneaza null daca nu exista
    }
}
using SistemRezervari.CORE.BookingLogic.Interfaces;

using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Searcher (Cauta terenuri libere pe baza criterilor)
public class FieldCatalogService : IFieldCatalogService
{
    private readonly List<Rezervare> _reservationList;
    private readonly List<Teren> _fieldList;
    private List<Teren> _filteredFieldList;
    
    public FieldCatalogService(IFileRepository repository)
    {
        _reservationList = repository.IncarcaRezervari();
        _fieldList = repository.IncarcaTerenuri();
        _filteredFieldList = new();
    }

    public List<Teren>? SearchFieldsBySport(string sportType)
    {
        _filteredFieldList = _fieldList
            .Where(f => f.TipSport == sportType).ToList();

        return _filteredFieldList.Count == 0 ? null : _filteredFieldList;
    }

    public List<Teren>? SearchFieldsByDate(string date)
    {
        var dateTime = DateTime.ParseExact(date, "dd/MM/yyyy", null);
        
        foreach(var field in _fieldList)
        {
            
        }

        throw new NotImplementedException();

    }

    public Teren? ViewInfoField(Guid fieldId)
    {
        var field = _fieldList.Find(f => f.Id == fieldId);
        
        return field; // Returneaza null daca nu exista
    }

    private List<string> SearchFreeHours()
    {
        throw new NotImplementedException();
    }
}
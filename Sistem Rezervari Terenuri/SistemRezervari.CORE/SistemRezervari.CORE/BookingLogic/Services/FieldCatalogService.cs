using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Services;

// Searcher (Cauta terenuri libere pe baza criterilor)
public class FieldCatalogService : IFieldCatalogService
{
    private ReservationRepository _reservationRepo;
    private FieldRepository _fieldRepository;
    public FieldCatalogService(ReservationRepository reservationRepo, FieldRepository fieldRepository)
    {
        _reservationRepo = reservationRepo;
        _fieldRepository = fieldRepository;
    }

    public List<Teren> SearchField(string sportType, DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }

    public Teren ViewInfoField(Guid fieldId)
    {
        throw new NotImplementedException();
    }
}
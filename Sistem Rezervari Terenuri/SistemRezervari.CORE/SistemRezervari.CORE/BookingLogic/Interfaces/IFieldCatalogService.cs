using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.BookingLogic.Interfaces;

public interface IFieldCatalogService
{
    public List<Teren> SearchField(string sportType, DateTime startTime);
    public Teren? ViewInfoField(Guid fieldId);
}
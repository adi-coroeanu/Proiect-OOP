using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.BookingLogic.Interfaces;

public interface IFieldCatalogService
{
    public List<Teren>? SearchFieldsBySport(string sportType);
    public List<Teren>? SearchFieldsByDate(string date);
    public Teren? ViewInfoField(Guid fieldId);
}
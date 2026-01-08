using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.BookingLogic.Interfaces;

public interface IFieldCatalogService
{
    public List<Teren>? SearchFieldsBySport(string sportType);
    public List<Teren>? SearchFieldsByDate(string date);
    public List<string>? GetAvailableSlots(Guid fieldId, string date);
}
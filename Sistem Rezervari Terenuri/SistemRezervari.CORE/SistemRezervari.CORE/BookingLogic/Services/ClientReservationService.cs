using SistemRezervari.CORE.BookingLogic.Interfaces;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.BookingLogic.Services;

// Creeaza rezervari noi
public class ClientReservationService : IClientReservationService
{
    private readonly IFileRepository _repository;
    private readonly List<Rezervare> _reservationList;
    private readonly List<Teren> _fieldList;

    public ClientReservationService(IFileRepository repository)
    {
        _repository = repository;
        _reservationList = _repository.IncarcaRezervari();
        _fieldList = _repository.IncarcaTerenuri();
    }

    public void MakeReservation(Guid fieldId, Guid userId, DateTime startDate)
    {
        int durataStandard = _fieldList.Find(f => f.Id == fieldId)?.durata_standard ?? 60;
        DateTime endDate = startDate.AddMinutes(durataStandard);
        
        var newReservation = new Rezervare
        (
            Guid.NewGuid(),
            fieldId,
            userId,
            startDate,
            endDate
        );
        
        _reservationList.Add(newReservation);
        _repository.SalveazaRezervari(_reservationList);
    }
}

using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.AdministrationLogic;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Data;
namespace SistemRezervari.CORE.Services;


public class AdministrareService: IAdministrareService
{
  
    private IFieldAdministration _fieldAdministration;
    private IReservationAdministration _reservationAdministration;
    private readonly IFileRepository _fileRepository;
    private readonly ILogger<AdministrareService> _logger;
    
    public AdministrareService(IFileRepository fileRepository, ILogger<AdministrareService> logger)
    {
        _fileRepository = fileRepository;
        _fieldAdministration = new FieldAdministration(_fileRepository);
        _reservationAdministration = new ReservationAdministration(_fileRepository);
        _logger = logger;
    }

    public void AddField(string name, string type, int capacity, string program,string intervale_indisponibile,int nr_max_rezervari, int durata_standard)
    {    
        _fieldAdministration.AddField(name, type, capacity, program,intervale_indisponibile,nr_max_rezervari,durata_standard);
        _logger.LogInformation($"Field {name} has been added");
    }

    public void RemoveField(Guid terenId)
    {
       _fieldAdministration.RemoveField(terenId);
       _logger.LogInformation($"Field has been removed");
    }

    public List<Teren> GetAllFields()
    {
        _logger.LogInformation($"Fields have been sent");
        return _fieldAdministration.GetAllFields();
    }

    public Teren GetFieldById(Guid terenId)
    {
        _logger.LogInformation($"Field has been sent");
        return _fieldAdministration.GetFieldById(terenId);
    }

    public void ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity,
        string newFieldProgram, string newFieldRestrictions,int nr_max_rezervari, int durata_standard)
    {
        _fieldAdministration.ModifyField(terenId, newFieldName, newFieldType, newFieldCapacity, newFieldProgram, newFieldRestrictions, nr_max_rezervari, durata_standard);
        _logger.LogInformation($"Field has been modified");
    }

    public void RemoveReservation(Guid reservationId)
    {
        _reservationAdministration.RemoveReservation(reservationId);
        _logger.LogInformation($"Reservation has been removed");
    }

    public void ModifyReservation(Guid reservationId, DateTime from)
    {
       _reservationAdministration.ModifyReservation(reservationId, from);
       _logger.LogInformation($"Reservation has been modified");
    }

    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        _logger.LogInformation($"Reservations have been sent");
        return _reservationAdministration.GetAllReservations(terenId);
    }

}
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.AdministrationLogic;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Data;
namespace SistemRezervari.CORE.Services;


public class AdministrareService: IAdministrareService
{
  
    private IFieldAdministration _fieldAdministration;
    private IReservationAdministration _reservationAdministration;
    private readonly IFileRepository _fileRepository;
    
    
    public AdministrareService(IFileRepository fileRepository)
    {
        _fileRepository = fileRepository;
        _fieldAdministration = new FieldAdministration(_fileRepository);
        _reservationAdministration = new ReservationAdministration(_fileRepository);
    }

    public void AddField(string name, string type, int capacity, string program,int nr_max_rezervari, int durata_standard)
    {    
        _fieldAdministration.AddField(name, type, capacity, program,nr_max_rezervari,durata_standard);
    }

    public void RemoveField(Guid terenId)
    {
       _fieldAdministration.RemoveField(terenId);
    }

    public List<Teren> GetAllFields()
    {
        return _fieldAdministration.GetAllFields();
    }

    public Teren GetFieldById(Guid terenId)
    {
        return _fieldAdministration.GetFieldById(terenId);
    }

    public void ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity,
        string newFieldProgram, string newFieldRestrictions,int nr_max_rezervari, int durata_standard)
    {
        _fieldAdministration.ModifyField(terenId, newFieldName, newFieldType, newFieldCapacity, newFieldProgram, newFieldRestrictions, nr_max_rezervari, durata_standard);
    }

    public void RemoveReservation(Guid reservationId)
    {
        _reservationAdministration.RemoveReservation(reservationId);
    }

    public void ModifyReservation(Guid reservationId, DateTime from)
    {
       _reservationAdministration.ModifyReservation(reservationId, from);
    }

    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        return _reservationAdministration.GetAllReservations(terenId);
    }

}
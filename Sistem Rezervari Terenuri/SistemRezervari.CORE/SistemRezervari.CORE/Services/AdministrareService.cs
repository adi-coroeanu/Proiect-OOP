using SistemRezervari.CORE.AdministrationLogic;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Services;

public class AdministrareService: IAdministrareService
{
    private ReservationRepository _reservationRepository;
    private FieldRepository _fieldRepository;
    private FieldAdministration _fieldAdministration;
    private ReservationAdministration _reservationAdministration;
    
    public AdministrareService(ReservationRepository reservationRepository,FieldRepository fieldRepository)
    {
      
        _reservationRepository = reservationRepository;
        _fieldRepository = fieldRepository;                
        
        _fieldAdministration = new FieldAdministration(_fieldRepository);
        _reservationAdministration = new ReservationAdministration(_reservationRepository);
    }

    public void AddField(string name, string type, int capacity, string program)
    {
        _fieldAdministration.AddField(name, type, capacity, program);
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
        string newFieldProgram, string newFieldRestrictions)
    {
        _fieldAdministration.ModifyField(terenId, newFieldName, newFieldType, newFieldCapacity, newFieldProgram, newFieldRestrictions);
    }

    public void RemoveReservation(Guid reservationId)
    {
        _reservationAdministration.RemoveReservation(reservationId);
    }

    public void ModifyReservation(Guid reservationId, DateTime from, DateTime to)
    {
       _reservationAdministration.ModifyReservation(reservationId, from, to);
    }

    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        return _reservationAdministration.GetAllReservations(terenId);
    }

}
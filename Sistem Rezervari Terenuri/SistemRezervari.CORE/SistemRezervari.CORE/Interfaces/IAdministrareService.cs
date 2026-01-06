using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IAdministrareService
{
    //metode la Teren
	public void AddField(string name,string type,int capacity,string program);
	public void RemoveField(Guid terenId);
	public List<Teren> GetAllFields();
	public Teren GetFieldById(Guid terenId);
	public void ModifyField(Guid terenId,string newFieldName, string newFieldType, int newFieldCapacity, string newFieldProgram,string newFieldRestrictions);
	//metode la Rezervari
	public void RemoveReservation(Guid reservationId);	
	public void ModifyReservation(Guid reservationId, DateTime from, DateTime to);//parametrii vor contine noile date ale unei rezervari
	public List<Rezervare> GetAllReservations(Guid terenId);
}
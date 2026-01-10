using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IAdministrareService
{
    //metode la Teren
	public void AddField(string name,string type,int capacity,string program,string intervale_indisponibile,int nr_max_rezervari, int durata_standard);
	public void RemoveField(Guid terenId);
	public List<Teren> GetAllFields();
	public Teren GetFieldById(Guid terenId);
	public void ModifyField(Guid terenId,string newFieldName, string newFieldType, int newFieldCapacity, string newFieldProgram,string newFieldRestrictions,int nr_max_rezervari, int durata_standard);
	//metode la Rezervari
	public void RemoveReservation(Guid reservationId);	
	public void ModifyReservation(Guid reservationId, string from);//parametrii vor contine noile date ale unei rezervari
	public List<Rezervare> GetAllReservations(Guid terenId);
	public Utilizator GetUserById(Guid userId);
}
using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IFieldAdministration
{
    public void AddField(string name,string type,int capacity,string program,string intervale_indisponibile,int nr_max_rezervari, int durata_standard);
    public void RemoveField(Guid terenId);
    public List<Teren> GetAllFields();
    public Teren GetFieldById(Guid terenId);
    public void ModifyField(Guid terenId,string newFieldName, string newFieldType, int newFieldCapacity, string newFieldProgram,string newFieldRestrictions,int nr_max_rezervari, int durata_standard);
    public Utilizator GetUserById(Guid userId);

}
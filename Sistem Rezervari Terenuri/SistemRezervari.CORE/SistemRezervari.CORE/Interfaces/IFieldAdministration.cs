using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IFieldAdministration
{
    public void AddField(string name,string type,int capacity,string program);
    public void RemoveField(Guid terenId);
    public List<Teren> GetAllFields();
    public Teren GetFieldById(Guid terenId);
    public void ModifyField(Guid terenId,string newFieldName, string newFieldType, int newFieldCapacity, string newFieldProgram,string newFieldRestrictions);
    

}
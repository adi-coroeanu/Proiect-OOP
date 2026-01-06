using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Data;

public class FieldRepository : IRepository<Teren>
{
    private List<Teren> _fields;

    public FieldRepository(List<Teren> fields)
    {
        _fields = fields;
    }
    
    public void Add(Teren value)
    {
        _fields.Add(value);
    }
    
    public List<Teren> GetCopyAll()
    {
        return new List<Teren>(_fields);
    }
}
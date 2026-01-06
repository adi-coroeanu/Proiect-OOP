using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Data;

public class UserRepository  
{
    private List<Utilizator> _users;
    
    public UserRepository(List<Utilizator> users)
    {
        _users = users;
    }
    
    public void Add(Utilizator value)
    {
        _users.Add(value);
    }
    
    public List<Utilizator> GetCopyAll()
    {
        return new List<Utilizator>(_users);
    }
    public void ModifyList(List<Utilizator> value)
    {
        _users = value;
    }
}
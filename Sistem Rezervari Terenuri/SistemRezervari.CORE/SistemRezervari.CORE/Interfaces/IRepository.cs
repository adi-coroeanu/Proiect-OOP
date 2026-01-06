namespace SistemRezervari.CORE.Interfaces;

public interface IRepository<T>
{
    public void Add(T value);
    public List<T> GetCopyAll();
    
}
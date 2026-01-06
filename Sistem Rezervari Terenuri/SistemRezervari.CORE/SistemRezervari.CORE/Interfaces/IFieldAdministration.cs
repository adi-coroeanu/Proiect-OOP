namespace SistemRezervari.CORE.Interfaces;

public interface IFieldAdministration
{
    public void AddField(string name, string tip_sport, int capacity,string program_de_functionare,string intervale_indisponibile,bool esteActiv);
    public void RemoveField(string name);
    public void ModifyField(int  option, object rezervation_param, int pozition);
    public void ModifyReservation();
    public void VisualizeRezervations();

}
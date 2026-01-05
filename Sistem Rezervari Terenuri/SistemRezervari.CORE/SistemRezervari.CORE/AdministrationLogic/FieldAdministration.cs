using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.AdministrationLogic;

public class FieldAdministration : IAdministrareService
{

    private List<Teren> _fields;
    private List<Rezervare> _reservations;

    public FieldAdministration(List<Teren> fields, List<Rezervare> reservations)
    {
        _fields = fields;
        _reservations = reservations;
    }

    
    
    #region Private Methods
    private void _AddField(string name, string tip_sport,int capacity,string program_de_functionare,string intervale_indisponibile,bool esteActiv)
    {
        _fields.Add(new Teren(Guid.NewGuid(), name, tip_sport,capacity,program_de_functionare,intervale_indisponibile,esteActiv));
    }

    private void _RemoveField(string name)
    {
        for(int i = 0; i < _fields.Count; i++)
        {
            if(_fields[i].Nume == name)
                _fields.RemoveAt(i);
        }
    }
    
    private void Case_1_met(Guid rezervation_param, int pozition)
    {
        for (int i = 0; i <= _fields.Count; i++)
            if (i == pozition)
            {
                var old_field = _fields[i];
                var new_field = old_field with { Id = rezervation_param };
                _fields[i] = new_field;
            }
    }
    
    private void Case_2_met(string rezervation_param, int pozition)
    {
        for (int i = 0; i <= _fields.Count; i++)
            if (i == pozition)
            {
                var old_field = _fields[i];
                var new_field = old_field with { Nume = rezervation_param };
                _fields[i] = new_field;
            }
    }
    
    private void Case_3_met(string rezervation_param, int pozition)
    {
        for (int i = 0; i <= _fields.Count; i++)
            if (i == pozition)
            {
                var old_field = _fields[i];
                var new_field = old_field with { TipSport = rezervation_param };
                _fields[i] = new_field;
            }
    }
    
    private void Case_4_met(int rezervation_param, int pozition)
    {
        for (int i = 0; i <= _fields.Count; i++)
            if (i == pozition)
            {
                var old_field = _fields[i];
                var new_field = old_field with { Capacitate = rezervation_param };
                _fields[i] = new_field;
            }
    }
    
    private void Case_5_met(string rezervation_param, int pozition)
    {
        for (int i = 0; i <= _fields.Count; i++)
            if (i == pozition)
            {
                var old_field = _fields[i];
                var new_field = old_field with { program_de_functionare = rezervation_param };
                _fields[i] = new_field;
            }
    }
    
    private void Case_6_met(string rezervation_param, int pozition)
    {
        for (int i = 0; i <= _fields.Count; i++)
            if (i == pozition)
            {
                var old_field = _fields[i];
                var new_field = old_field with { intervale_indisponibile = rezervation_param };
                _fields[i] = new_field;
            }
    }
   #endregion 
    
    #region Public Methods
    public void AddField(string name, string tip_sport,int capacity,string program_de_functionare,string intervale_indisponibile,bool esteActiv)
    {
        _AddField(name,tip_sport,capacity,program_de_functionare,intervale_indisponibile,esteActiv);
    }
    

    public void RemoveField(string name)
    {
        _RemoveField(name);
    }
    

    public void ModifyField(int option, object rezervation_param, int pozition)
    {
        switch (option)
        {
            case 1:
               Case_1_met((Guid)rezervation_param, pozition);
                break;
            
            case 2:
                Case_2_met((string)rezervation_param, pozition);
                break;
            
            case 3:
                Case_3_met((string)rezervation_param, pozition);
                break;
            
            case 4:
                Case_4_met((int)rezervation_param, pozition);
                break;
            
            case 5:
                Case_5_met((string)rezervation_param, pozition);
                break;
            
            case 6:
                Case_6_met((string)rezervation_param, pozition);
                break;
            
            default:
                break;
        }
    }

    public void ModifyReservation()
    {
        throw new NotImplementedException();
    }

    public void VisualizeRezervations()
    {
        throw new NotImplementedException();
    }

    #endregion
}
namespace SistemRezervari.UI;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;
public partial class ClientResForm : Form
{
    
    public ClientResForm()
    {
        InitializeComponent();
    }

    public void SlotConfig(List<string> slots)
    {
        foreach (var slot in slots)
        {
            listBoxAvailable.Items.Add(slot);
        }
    }
}
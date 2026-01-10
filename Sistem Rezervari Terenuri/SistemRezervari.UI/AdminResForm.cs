namespace SistemRezervari.UI;

using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Entities;

public partial class AdminResForm : Form
{   private readonly IAdministrareService _administrareService;
    private Teren _field;
    
    public AdminResForm(IAdministrareService administrareService)
    {
        InitializeComponent();
        _administrareService = administrareService;
    }

    public void SetField(Teren field)
    {
        _field = field;
    }


    private void AdminResForm_Load(object sender, EventArgs e)
    {
        List<Rezervare> rezervari;
        rezervari = _administrareService.GetAllReservations(_field.Id);
        if (rezervari.Count > 0)
        {
            foreach (var rezervare in rezervari)
            {
                string date = rezervare.DataInceput.ToShortDateString();
                string hour = rezervare.DataInceput.ToShortTimeString();
                listboxReservations.Items.Add($"{date} {hour}");
            }
        }
    }

    private void listboxReservations_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listboxReservations.SelectedIndex != -1)
        {   
            
            labelUser.Visible = true;

            labelUser.Text = $"Made by: ";
        }
    }
}
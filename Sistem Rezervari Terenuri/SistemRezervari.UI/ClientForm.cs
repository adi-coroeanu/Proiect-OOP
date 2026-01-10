using Microsoft.Extensions.DependencyInjection;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.UI;

public partial class ClientForm : Form
{
    private readonly IBookingService _bookingService;
    private readonly IServiceProvider _serviceProvider;
    private Utilizator _user;
    public ClientForm(IBookingService bookingService,IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _bookingService = bookingService;
        _serviceProvider = serviceProvider;
    }

    public void UserConfig(Utilizator user)
    {
        _user = user;
        labelUser.Text = $"Welcome back, \n{_user.Username}";
        UpdateReservations();
    }

    private void UpdateReservations()
    {
        foreach (var var in _bookingService.GetUserReservations(_user.Id))
        {
            string date = var.DataInceput.ToShortDateString();
            string start = var.DataInceput.ToShortTimeString();
            string end = var.DataSfarsit.ToShortTimeString();
            listBoxRes.Items.Clear();
            listBoxRes.Items.Add($"{date} {start} -- {end}");
        }
    }

    private void comboBoxSport_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxSport.Location = new Point(622, 64);
        listboxFields.Visible = true;
        labelLoad.Visible = false;
        listboxFields.Items.Clear();
        List<Teren> terenuri = _bookingService.SearchFieldsBySport(comboBoxSport.SelectedItem.ToString());
        foreach (var item in terenuri)
            listboxFields.Items.Add(item.Nume);
    }

    private void ClientForm_Click(object sender, EventArgs e)
    {
        listboxFields.SelectedIndex = -1;
        listBoxRes.SelectedIndex = -1;
    }

    private void listboxFields_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listboxFields.SelectedIndex != -1)
        {
            btnView.Visible = true;
            dateTimePicker1.Visible = true;
        }
        else
        {
            btnView.Visible = false;
            dateTimePicker1.Visible = false;
        }
    }

    private void listBoxRes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxRes.SelectedIndex != -1)
        {
            btnCancel.Visible = true;
        }
        else
        {
            btnCancel.Visible = false;
        }
    }

    private void btnView_Click(object sender, EventArgs e)
    {
        var resform = _serviceProvider.GetRequiredService<ClientResForm>();
        string date = dateTimePicker1.Value.ToShortDateString();
        Guid id =
            _bookingService.SearchFieldsBySport(comboBoxSport.SelectedItem.ToString())[listboxFields.SelectedIndex].Id;
        //problema la adi
        resform.SlotConfig(_bookingService.GetAvailableSlots(id,date));
        resform.Show();
    }
}
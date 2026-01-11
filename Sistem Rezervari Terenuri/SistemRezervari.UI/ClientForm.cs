using Microsoft.Extensions.DependencyInjection;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.UI;

public partial class ClientForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private IBookingService _bookingService;
    private Utilizator _user;
    private List<Rezervare> _currentReservations; // Keep track of reservations

    public ClientForm(IBookingService bookingService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _bookingService = bookingService;
        _serviceProvider = serviceProvider;
        _currentReservations = new List<Rezervare>();
    }

    public void UserConfig(Utilizator user)
    {
        _user = user;
        labelUser.Text = $"Welcome back, \n{_user.Username}";
        UpdateReservations();
    }

    private void UpdateReservations()
    {
        // Get fresh service instance to avoid cached data
        _bookingService = _serviceProvider.GetRequiredService<IBookingService>();

        listBoxRes.Items.Clear();
        _currentReservations.Clear();
        
        var reservations = _bookingService.GetUserReservations(_user.Id);

        if (reservations != null)
        {
            _currentReservations.AddRange(reservations);
            
            foreach (var var in reservations)
            {
                string date = var.DataInceput.ToShortDateString();
                string start = var.DataInceput.ToShortTimeString();
                string end = var.DataSfarsit.ToShortTimeString();
                listBoxRes.Items.Add($"{date} {start} -- {end}");
            }
        }
    }

    private void comboBoxSport_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBoxSport.Location = new Point(711, 99);
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

        resform.Config(_bookingService.GetAvailableSlots(id, date), _user.Id, id, date);
        resform.ShowDialog();

        // Clear selections
        listboxFields.SelectedIndex = -1;
        listBoxRes.SelectedIndex = -1;
        btnView.Visible = false;
        dateTimePicker1.Visible = false;

        // This will now get a fresh service instance
        UpdateReservations();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        if (listBoxRes.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a reservation to cancel.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Confirm deletion
        var result = MessageBox.Show(
            "Are you sure you want to cancel this reservation?", 
            "Confirm Cancellation", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                // Get the reservation ID from the list
                Guid reservationId = _currentReservations[listBoxRes.SelectedIndex].Id;
                
                // Delete the reservation
                _bookingService.DeleteReservation(reservationId);
                
                MessageBox.Show("Reservation cancelled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Hide the cancel button
                btnCancel.Visible = false;
                
                // Refresh the list
                UpdateReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling reservation: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
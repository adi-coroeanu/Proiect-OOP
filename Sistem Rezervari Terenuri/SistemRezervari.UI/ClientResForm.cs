namespace SistemRezervari.UI;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;
public partial class ClientResForm : Form
{
    private readonly IBookingService _bookingService;
    Guid _idUser,_idField;
    string _date;
    public ClientResForm(IBookingService bookingService)
    {
        InitializeComponent();
        _bookingService = bookingService;
    }

    public void Config(List<string> slots,Guid idUser,Guid idField,string date)
    {
        _idUser = idUser;
        _idField = idField;
        _date = date;
        foreach (var slot in slots)
        {
            listBoxAvailable.Items.Add(slot);
        }
    }

    private void btnReservation_Click(object sender, EventArgs e)
    {
        // Validate selection
        if (listBoxAvailable.SelectedItem == null)
        {
            MessageBox.Show("Please select a time slot.", "No Selection", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Parse date in format yyyy-MM-dd
        string[] s = _date.Split('-');
        if (s.Length != 3 ||
            !int.TryParse(s[0], out int year) ||
            !int.TryParse(s[1], out int month) ||
            !int.TryParse(s[2], out int day))
        {
            MessageBox.Show("Invalid date format.", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Get selected time slot (e.g., "09:00-10:00")
        string time = listBoxAvailable.SelectedItem.ToString();
        
        // Extract start time (before the dash)
        string[] timeParts = time.Split('-');
        if (timeParts.Length == 0)
        {
            MessageBox.Show("Invalid time format.", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        string startTime = timeParts[0].Trim();
        string[] hourMinute = startTime.Split(':');
        
        if (hourMinute.Length != 2 ||
            !int.TryParse(hourMinute[0], out int hour) ||
            !int.TryParse(hourMinute[1], out int minute))
        {
            MessageBox.Show("Invalid time format.", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);
            _bookingService.MakeReservation(_idField, _idUser, dateTime);
            
            MessageBox.Show("Reservation successful!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Reservation failed: {ex.Message}", "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
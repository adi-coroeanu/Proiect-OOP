namespace SistemRezervari.UI;

using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Entities;

public partial class AdminResForm : Form
{   private readonly IAdministrareService _administrareService;
    private Teren _field;
    private List<Rezervare> rezervari;
    public AdminResForm(IAdministrareService administrareService)
    {
        InitializeComponent();
        _administrareService = administrareService;
        
    }

    private void ChangeRes(int index, string date, string hour)
    {
        listboxReservations.Items[index] = $"{date} {hour}";
    }

    public void SetField(Teren field)
    {
        _field = field;
    }


    private void AdminResForm_Load(object sender, EventArgs e)
    {
        
        
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
        else
        {   label2.Visible = false;
            listboxReservations.Visible = false;
            label1.Visible = true;
            label1.Text = "No active reservations";
        }
    }

    private void listboxReservations_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listboxReservations.SelectedIndex != -1)
        {
            try
            {
                Utilizator user =
                    _administrareService.GetUserById(rezervari[listboxReservations.SelectedIndex].UtilizatorId);
                label1.Visible = true;
                labelUser.Visible = true;
                labelFrom.Visible = true;
                labelTo.Visible = true;
                txtFrom.Visible = true;
                txtTo.Visible = true;
                labelDay.Visible = true;
                dateTimePicker1.Visible = true;
                btnModify.Visible = true;
                btnRemove.Visible = true;
                //
                string userId = user.Id.ToString();
                labelUser.Text = $"Made by: {user.Username}";
                
                string[] dateandtime = listboxReservations.Items[listboxReservations.SelectedIndex].ToString().Split(" ");
                string[] date = dateandtime[0].Split("/");
                dateTimePicker1.Value = new  DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                txtFrom.Text = dateandtime[1];
                string[] time = dateandtime[1].Split(":");
                txtTo.Text = new TimeOnly(int.Parse(time[0]), int.Parse(time[1])).AddMinutes(_field.durata_standard).ToString();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        else
        {
            label1.Visible = false;
            labelUser.Visible = false;
            labelFrom.Visible = false;
            labelTo.Visible = false;
            txtFrom.Visible = false;
            txtTo.Visible = false;
            labelDay.Visible = false;
            dateTimePicker1.Visible = false;
            btnModify.Visible = false;
            btnRemove.Visible = false;
        }
    }

    private void AdminResForm_Click(object sender, EventArgs e)
    {
        listboxReservations.SelectedIndex = -1;
    }

    private void btnModify_Click(object sender, EventArgs e)
    {

        try
        {
            string date = dateTimePicker1.Value.ToShortDateString();
            string time = txtFrom.Text;
            Guid id = rezervari[listboxReservations.SelectedIndex].Id;
            _administrareService.ModifyReservation(id,$"{date} {time}");
            ChangeRes(listboxReservations.SelectedIndex, date, time);
            listboxReservations.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            Guid id = rezervari[listboxReservations.SelectedIndex].Id;
            _administrareService.RemoveReservation(id);
            listboxReservations.Items.RemoveAt(listboxReservations.SelectedIndex);

        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
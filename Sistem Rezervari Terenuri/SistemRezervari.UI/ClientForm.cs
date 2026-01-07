using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.UI;

public partial class ClientForm : Form
{
    private readonly IBookingService _bookingService;
    public ClientForm(IBookingService bookingService)
    {
        InitializeComponent();
        _bookingService = bookingService;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        string sport = txtSport.Text;
        string time = txtStart.Text;
        DateTime dtime = DateTime.Now;
        List<Teren> terenuri = _bookingService.SearchField(sport,dtime);
        foreach(Teren teren in terenuri)
            listBox1.Items.Add(teren.Nume);
    }
}
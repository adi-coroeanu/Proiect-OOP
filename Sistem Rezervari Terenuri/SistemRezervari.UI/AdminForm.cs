using SistemRezervari.CORE.Interfaces;
namespace SistemRezervari.UI;

public partial class AdminForm : Form
{
    private readonly IAdministrareService _administrareService;

    public AdminForm(IAdministrareService administrareService)
    {
        InitializeComponent();
        _administrareService = administrareService;
    }
    public AdminForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        _administrareService.AddField();
    }
}
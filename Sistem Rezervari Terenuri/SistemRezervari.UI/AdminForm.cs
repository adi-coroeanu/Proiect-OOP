using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Entities;
namespace SistemRezervari.UI;

public partial class AdminForm : Form
{
    private readonly IAdministrareService _administrareService;

    public AdminForm(IAdministrareService administrareService)
    {
        InitializeComponent();
        _administrareService = administrareService;
    }
    

    private void button1_Click(object sender, EventArgs e)
    {
        foreach (var var in _administrareService.GetAllFields())
        {
            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
            listBox1.Items.Add(var.Nume);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _administrareService.AddField(textBox1.Text,textBox2.Text,int.Parse(textBox3.Text),textBox4.Text,int.Parse(textBox5.Text),int.Parse(textBox6.Text));
        listBox1.Items.Add(_administrareService.GetAllFields().Last().Nume);
    }
}
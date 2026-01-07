using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Entities;
namespace SistemRezervari.UI;

public partial class AdminForm : Form
{
    private readonly IAdministrareService _administrareService;
    private List<Teren> _fields;
    
    public AdminForm(IAdministrareService administrareService)
    {
        InitializeComponent();
        _administrareService = administrareService;
        _fields = _administrareService.GetAllFields();
        
    }
    

    private void button1_Click(object sender, EventArgs e)
    {
        foreach (var var in _administrareService.GetAllFields())
        {
            listBox1.Items.Add(var.Nume);
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text;
        string type = textBox2.Text;
        int capacity = int.Parse(textBox3.Text);
        string program = textBox4.Text;
        string interv_in = textBox5.Text;
        int nr_max = int.Parse(textBox6.Text);
        int durata = int.Parse(textBox7.Text);
        _administrareService.AddField(name,type,capacity,program,interv_in,nr_max,durata);
        listBox1.Items.Add(_administrareService.GetAllFields().Last().Nume);
    }

    private void button3_Click(object sender, EventArgs e)
    {
        int index = listBox1.SelectedIndex;
        _administrareService.RemoveField(_administrareService.GetAllFields()[index].Id);
        listBox1.Items.RemoveAt(index);
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = listBox1.SelectedIndex;
        Teren teren = _administrareService.GetAllFields()[index];
        textBox1.Text=teren.Nume;
        textBox2.Text=teren.TipSport;
        textBox3.Text = teren.Capacitate.ToString();
        textBox4.Text = teren.program_de_functionare;
        textBox5.Text = teren.intervale_indisponibile;
        textBox6.Text = teren.nr_max_rezervari.ToString();
        textBox7.Text = teren.durata_standard.ToString();
        btnModify.Enabled = true;
            
    }

    private void btnModify_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text;
        string type = textBox2.Text;
        int capacity = int.Parse(textBox3.Text);
        string program = textBox4.Text;
        string interv_in = textBox5.Text;
        int nr_max = int.Parse(textBox6.Text);
        int durata = int.Parse(textBox7.Text);
        Guid id = _fields[listBox1.SelectedIndex].Id;
        _administrareService.ModifyField(id,name, type, capacity, program, interv_in, nr_max, durata);
        btnModify.Enabled = false;
    }
}
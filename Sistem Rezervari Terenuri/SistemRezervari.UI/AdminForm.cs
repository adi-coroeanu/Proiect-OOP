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
    
    private void AdminForm_Load(object sender, EventArgs e)
    {
        foreach (var var in _administrareService.GetAllFields())
        {
            listboxFields.Items.Add(var.Nume);
        }

        TabIndex = 0;
        
        
    }

    private void AdminForm_Click(object sender, EventArgs e)
    {
        listboxFields.SelectedIndex = -1;
    }
    
    public void UserConfig(string username)
    {
        txtUser.Text = $"Welcome back,\n{username}";
    }
    
    private void listboxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            int index = listboxFields.SelectedIndex;
            if (index != -1){
                btnAdd.Visible = false;
                btnRemove.Visible = true;
                btnModify.Visible = true;
                Teren teren = _administrareService.GetAllFields()[index];
                txtName.Text = teren.Nume;
                comboBoxType.SelectedItem=comboBoxType.Items[comboBoxType.Items.IndexOf(teren.TipSport)];
                txtCapacity.Text = teren.Capacitate.ToString();
                txtOpenFT.Text = teren.program_de_functionare;
                txtClosedFT.Text = teren.intervale_indisponibile;
                txtMaxRes.Text = teren.nr_max_rezervari.ToString();
                txtResDur.Text = teren.durata_standard.ToString();
                
        }
            else
            {
                btnAdd.Visible = true;
                btnRemove.Visible = false;
                btnModify.Visible = false;
                txtName.Clear();
                comboBoxType.SelectedItem=null;
                txtCapacity.Clear();
                txtOpenFT.Clear();
                txtClosedFT.Clear();
                txtMaxRes.Clear();
                txtResDur.Clear();
                
            }
        }
    
    private void btnView_Click(object sender, EventArgs e)
    {
        foreach (var var in _administrareService.GetAllFields())
        {
            listboxFields.Items.Add(var.Nume);
        }
    }
    
    private void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Invalid name!");
                return; // Oprim execuția aici
            }

            if (comboBoxType.SelectedIndex == -1)
            {
                errorProvider1.SetError(comboBoxType, "Please select a type!");
                return;
            }

            if (!int.TryParse(txtCapacity.Text, out int capacity))
            {
                errorProvider1.SetError(txtCapacity, "Invalid number!");
                return;
            }
            if (!int.TryParse(txtMaxRes.Text, out int nr_max))
            {
                errorProvider1.SetError(txtMaxRes, "Invalid number!");
                return;
            }

            if (!int.TryParse(txtResDur.Text, out int durata))
            {
                errorProvider1.SetError(txtResDur, "Invalid number!");
                return;
            }
            _administrareService.AddField(
                txtName.Text, 
                comboBoxType.Text, 
                capacity, 
                txtOpenFT.Text, 
                txtClosedFT.Text, 
                nr_max, 
                durata
            );
            if (_administrareService.GetAllFields().Count != listboxFields.Items.Count)
                listboxFields.Items.Add(_administrareService.GetAllFields().Last().Nume);
            else
                throw new Exception("Format error! Accepted format hh:mm-hh:mm(or hh:mm-hh:mm,hh:mm-hh:mm)");

        }
        catch (Exception ex)
        {
            errorProvider1.SetError(txtOpenFT, ex.Message);
            errorProvider1.SetError(txtClosedFT, ex.Message);
            MessageBox.Show(ex.Message);
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    { 
        int index = listboxFields.SelectedIndex;
        if (index != -1)
        {
            _administrareService.RemoveField(_administrareService.GetAllFields()[index].Id);
            listboxFields.Items.RemoveAt(index);
        }
        else
        {
            MessageBox.Show("A field needs to be selected before removal!","Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    
    private void btnModify_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string type = comboBoxType.SelectedItem.ToString();
        int capacity = int.Parse(txtCapacity.Text);
        string program = txtOpenFT.Text;
        string interv_in = txtClosedFT.Text;
        int nr_max = int.Parse(txtMaxRes.Text);
        int durata = int.Parse(txtResDur.Text);
        Guid id = _fields[listboxFields.SelectedIndex].Id;
        _administrareService.ModifyField(id,name, type, capacity, program, interv_in, nr_max, durata);
        btnModify.Visible = false;
        listboxFields.SelectedIndex = -1;
    }
    
    
    
}
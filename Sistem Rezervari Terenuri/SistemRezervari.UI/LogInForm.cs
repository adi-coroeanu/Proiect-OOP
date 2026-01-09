namespace SistemRezervari.UI;

using Microsoft.Extensions.DependencyInjection;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

public partial class LogInForm : Form
{
    private readonly IAutentificareService _autentificareService;
    private readonly IServiceProvider _serviceProvider;

    public LogInForm(IAutentificareService autentificareService, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _autentificareService = autentificareService; 
        _serviceProvider = serviceProvider;
    }
    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            
            e.SuppressKeyPress = true;

            
            this.SelectNextControl((Control)sender, true, true, true, true);
        }
    }

    private void TextBox2_Enter(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnLogIn.PerformClick();
        }
    }

    private void btnLogIn_Click(object sender, EventArgs e)
    {
        string user = txtUser.Text;
        string pass = txtPass.Text;

        try
        {
          
            var utilizator = _autentificareService.Login(user, pass);

            if (utilizator != null)
            {
              
                this.Hide(); 

                if (utilizator.Rol == "Admin")
                {
                    // Cerem AdminForm de la Host (ca să aibă și el serviciile lui injectate)
                    var adminForm = _serviceProvider.GetRequiredService<AdminForm>();
                    adminForm.UserConfig(utilizator.Username);
                    // (Opțional) Îi trimitem numele userului
                    // adminForm.ConfigureazaUtilizator(utilizator.Username, utilizator.Rol);
                    
                    adminForm.FormClosed += (s, args) => this.Close();
                    adminForm.Show();
                }
                else
                {
                    // Deschidem ClientForm
                    var clientForm = _serviceProvider.GetRequiredService<ClientForm>();
                    clientForm.FormClosed += (s, args) => this.Close();
                    clientForm.Show();
                }
            }
            else
            {
                // -- EȘEC --
                MessageBox.Show("Nume sau parolă incorectă!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Eroare critică: {ex.Message}");
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Services;
using SistemRezervari.CORE.Data;

namespace SistemRezervari.UI;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                
                services.AddTransient<IAdministrareService, AdministrareService>();
                services.AddTransient<IAutentificareService, AutentificareService>();
                services.AddTransient<IBookingService, BookingService>();
                services.AddSingleton<IFileRepository, JsonRepository>();
                // Inregistram formularul
                services.AddTransient<AdminForm>();
                services.AddTransient<LogInForm>(); 
                services.AddTransient<ClientForm>();
                services.AddTransient<AdminResForm>();
                services.AddTransient<ClientResForm>();
                services.AddLogging(configure => configure.AddConsole());
            })
            .Build();

        try 
        {
            var mainForm = host.Services.GetRequiredService<LogInForm>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Eroare: {ex.Message}");
        }
    }
}
using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Interfaces;

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
                // Folosim FakeService pana termina colegii
                services.AddTransient<IAdministrareService, FakeService>();

                // Inregistram formularul
                services.AddTransient<AdminForm>(); 

                services.AddLogging(configure => configure.AddConsole());
            })
            .Build();

        try 
        {
            var mainForm = host.Services.GetRequiredService<AdminForm>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Eroare: {ex.Message}");
        }
    }
}
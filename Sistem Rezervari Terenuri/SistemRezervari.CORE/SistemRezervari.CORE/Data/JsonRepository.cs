using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.CORE.Data;

public class JsonRepository : IFileRepository
{
    private readonly ILogger<JsonRepository> _logger;
    
    // Definim numele folderului și căile către fișiere în interiorul acestuia
    private readonly string _directoryPath;
    private readonly string _pathTerenuri;
    private readonly string _pathRezervari;
    private readonly string _pathUtilizatori;

    public JsonRepository(ILogger<JsonRepository> logger)
    {
        _logger = logger;

        // Construim căile folosind Path.Combine pentru a fi siguri că formatul e corect (FisiereJson/fisier.json)
        _directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "FisiereJson");
        _pathTerenuri = Path.Combine(_directoryPath, "terenuri.json");
        _pathRezervari = Path.Combine(_directoryPath, "rezervari.json");
        _pathUtilizatori = Path.Combine(_directoryPath, "utilizatori.json");

       
    }
    

    // --- IMPLEMENTARE PENTRU TERENURI ---

    public List<Teren> IncarcaTerenuri()
    {
        return CitesteDinFisier<Teren>(_pathTerenuri);
    }

    public void SalveazaTerenuri(List<Teren> terenuri)
    {
        ScrieInFisier(_pathTerenuri, terenuri);
    }

    // --- IMPLEMENTARE PENTRU REZERVĂRI ---

    public List<Rezervare> IncarcaRezervari()
    {
        return CitesteDinFisier<Rezervare>(_pathRezervari);
    }

    public void SalveazaRezervari(List<Rezervare> rezervari)
    {
        ScrieInFisier(_pathRezervari, rezervari);
    }

    // --- IMPLEMENTARE PENTRU UTILIZATORI ---

    public List<Utilizator> IncarcaUtilizatori()
    {
        return CitesteDinFisier<Utilizator>(_pathUtilizatori);
    }

    public void SalveazaUtilizatori(List<Utilizator> utilizatori)
    {
        ScrieInFisier(_pathUtilizatori, utilizatori);
    }

    // --- METODE GENERICE AJUTĂTOARE ---

    private List<T> CitesteDinFisier<T>(string path)
    {
        try
        {
            if (!File.Exists(path)) return new List<T>();

            string json = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(json)) return new List<T>();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Eroare la citirea fișierului {Path}", path);
            return new List<T>();
        }
    }

    private void ScrieInFisier<T>(string path, List<T> data)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(path, json);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Eroare la salvarea fișierului {Path}", path);
            throw;
        }
    }
}
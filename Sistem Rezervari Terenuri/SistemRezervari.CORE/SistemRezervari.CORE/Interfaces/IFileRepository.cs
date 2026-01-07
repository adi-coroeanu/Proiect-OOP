using System.Collections.Generic;
using SistemRezervari.CORE.Entities;

namespace SistemRezervari.CORE.Interfaces;

public interface IFileRepository
{
    // --- 1. TERENURI (Folosite de AdminForm si ClientForm) ---
    List<Teren> IncarcaTerenuri();
    void SalveazaTerenuri(List<Teren> terenuri);

    // --- 2. REZERVARI (Folosite de BookingService) ---
    List<Rezervare> IncarcaRezervari();
    void SalveazaRezervari(List<Rezervare> rezervari);

    // --- 3. UTILIZATORI (Folosit de AutentificareService - LOGIN) ---
    // Aceasta este metoda critică pentru selecția ta.
    // Login-ul va apela asta ca să vadă dacă userul există.
    List<Utilizator> IncarcaUtilizatori();

    // (Opțional) Dacă vrei să faci și buton de "Înregistrare / Sign Up" pe viitor
    void SalveazaUtilizatori(List<Utilizator> utilizatori);
}
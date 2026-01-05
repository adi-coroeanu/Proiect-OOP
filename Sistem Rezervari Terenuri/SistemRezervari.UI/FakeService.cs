using System;
using System.Collections.Generic;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.UI;


public class FakeService : IAdministrareService
{
    public void AddField()
    {
        MessageBox.Show("Teren adaugat cu succes!");
    }

    public void RemoveField()
    {
        MessageBox.Show("Teren sters cu succes!");
    }

    public void ModifyField()
    {
        throw new NotImplementedException();
    }
}
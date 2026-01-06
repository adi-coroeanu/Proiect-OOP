using System;
using System.Collections.Generic;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace SistemRezervari.UI;


public class FakeService : IAdministrareService
{
    public void AddField(string name, string type, string capacity, string program)
    {
        throw new NotImplementedException();
    }

    public void RemoveField(Guid terenId)
    {
        throw new NotImplementedException();
    }

    public List<Teren> GetAllFields()
    {
        throw new NotImplementedException();
    }

    public Teren GetFieldById(Guid terenId)
    {
        throw new NotImplementedException();
    }

    public void ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity, string newFieldProgram)
    {
        throw new NotImplementedException();
    }

    public void ModifyField(Guid terenId, string newFieldName, string newFieldType, int newFieldCapacity, string newFieldProgram,
        string newFieldRestrictions)
    {
        throw new NotImplementedException();
    }

    public void RemoveReservation(Guid reservationId)
    {
        throw new NotImplementedException();
    }

    public void ModifyReservation(Guid reservationId, DateTime from, DateTime to)
    {
        throw new NotImplementedException();
    }

    public List<Rezervare> GetAllReservations(Guid terenId)
    {
        throw new NotImplementedException();
    }
}
using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; 
using SistemRezervari.CORE.AdministrationLogic;
using SistemRezervari.CORE.Data;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

public class ReservationAdministrationTests
{
    private readonly Mock<IFileRepository> _mockRepo;
    private readonly ReservationAdministration _sut; 
    private readonly List<Rezervare> _fakeReservations;
    private readonly List<Teren> _fakeFields;

    public ReservationAdministrationTests()
    {
        _mockRepo = new Mock<IFileRepository>();
        Guid terenIdFotbal = Guid.NewGuid();
        Guid terenIdTenis = Guid.NewGuid();
        Guid utilizatorId = Guid.NewGuid(); 
      
        _fakeFields = new List<Teren>
        {
            new Teren(terenIdFotbal, "Teren Fotbal", "Fotbal", 10, "08:00-22:00", "none", 2, 120),
            new Teren(terenIdTenis, "Teren Tenis", "Tenis", 4, "08:00-20:00", "none", 2, 60)
        };
        
        _fakeReservations = new List<Rezervare>
        {
            new Rezervare(
                Guid.NewGuid(),           
                terenIdFotbal,            
                utilizatorId,             
                DateTime.Now,             
                DateTime.Now.AddHours(2)  
            )
        };
        _mockRepo.Setup(r => r.IncarcaRezervari()).Returns(_fakeReservations);
        _mockRepo.Setup(r => r.IncarcaTerenuri()).Returns(_fakeFields);

        
        _sut = new ReservationAdministration(_mockRepo.Object);
    }

    [Fact]
    public void GetAllReservations_ShouldFilterByTerenId()
    {
        
        var terenCautat = _fakeReservations[0].TerenId; 
        var result = _sut.GetAllReservations(terenCautat);
        
        Assert.Single(result); 
        Assert.Equal(terenCautat, result[0].TerenId);
    }

    [Fact]
    public void RemoveReservation_ShouldRemoveFromList_And_Save()
    {
        
        var rezervareDeSters = _fakeReservations[0];
        _sut.RemoveReservation(rezervareDeSters.Id);
        
        Assert.Empty(_fakeReservations); 
        _mockRepo.Verify(r => r.SalveazaRezervari(It.IsAny<List<Rezervare>>()), Times.Once);
    }

    [Fact]
    public void ModifyReservation_ShouldUpdateDate_And_RecalculateEndTime_Correctly()
    {
      
        var rezervare = _fakeReservations[0]; 
        string dataNouaString = "25/12/2025"; 
        _sut.ModifyReservation(rezervare.Id, dataNouaString);
        var rezervareModificata = _fakeReservations.First(r => r.Id == rezervare.Id);
        
        DateTime expectedStart = new DateTime(2025, 12, 25);
        Assert.Equal(expectedStart, rezervareModificata.DataInceput);
        
        DateTime expectedEnd = expectedStart.AddHours(2);
        
        Assert.Equal(expectedEnd, rezervareModificata.DataSfarsit);
        
        Assert.Equal(rezervare.UtilizatorId, rezervareModificata.UtilizatorId);

        _mockRepo.Verify(r => r.SalveazaRezervari(It.IsAny<List<Rezervare>>()), Times.Once);
    }

    [Fact]
    public void ModifyReservation_ShouldThrow_WhenMonthIsInvalid()
    {
     
        var id = _fakeReservations[0].Id;
        string dataGresita = "10/15/2025"; 
        var ex = Assert.Throws<InvalidDataException>(() => _sut.ModifyReservation(id, dataGresita));
        Assert.Contains("Luna trebuie să fie între 1 și 12", ex.Message);
    }

    [Fact]
    public void ModifyReservation_ShouldThrow_WhenDayIsInvalid()
    {
        
        var id = _fakeReservations[0].Id;
        string dataGresita = "35/05/2025";
        var ex = Assert.Throws<InvalidDataException>(() => _sut.ModifyReservation(id, dataGresita));
        Assert.Contains("Ziua trebuie să fie între 1 și 31", ex.Message);
    }

    [Fact]
    public void ModifyReservation_ShouldThrow_WhenDayIsInvalidForSpecificMonth()
    {
     
        var id = _fakeReservations[0].Id;
        string dataGresita = "30/02/2025"; 
        var ex = Assert.Throws<InvalidDataException>(() => _sut.ModifyReservation(id, dataGresita));
        Assert.Contains("Luna 2 din anul 2025 nu are 30 zile", ex.Message);
    }

    [Fact]
    public void ModifyReservation_ShouldThrow_Exception_IfStringIsGarbage()
    {
        var id = _fakeReservations[0].Id;
        string dataGresita = "text_aiurea"; 
        
        Assert.ThrowsAny<Exception>(() => _sut.ModifyReservation(id, dataGresita));
    }
}
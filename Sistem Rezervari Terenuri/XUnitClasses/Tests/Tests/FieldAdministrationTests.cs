using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemRezervari.CORE.AdministrationLogic;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace Tests;

public class FieldAdministrationTests
{
    private readonly Mock<IFileRepository> _mockRepo;
    private readonly FieldAdministration _sut; 
    private readonly List<Teren> _fakeDatabase;

    public FieldAdministrationTests()
    {
        
        _fakeDatabase = new List<Teren>
        {
            
            new Teren(Guid.NewGuid(), "Teren Fotbal", "Fotbal", 10, "08:00-22:00", "none", 2, 60),
            new Teren(Guid.NewGuid(), "Teren Tenis", "Tenis", 4, "10:00-20:00", "12:00-13:00", 1, 60)
        };

       
        _mockRepo = new Mock<IFileRepository>();
        _mockRepo.Setup(repo => repo.IncarcaTerenuri()).Returns(_fakeDatabase);
        
        _sut = new FieldAdministration(_mockRepo.Object);
    }

    [Fact]
    public void AddField_ShouldAddToList_And_CallSave()
    {
        string name = "Teren Nou";
        
        _sut.AddField(name, "Baschet", 10, "09:00-18:00", "none", 3, 90);

      
        Assert.Equal(3, _fakeDatabase.Count);
        Assert.Contains(_fakeDatabase, t => t.Nume == name);
        _mockRepo.Verify(r => r.SalveazaTerenuri(It.IsAny<List<Teren>>()), Times.Once);
    }

    [Fact]
    public void RemoveField_ShouldRemoveFromList_And_CallSave()
    {
       
        var terenDeSters = _fakeDatabase[0]; 

      
        _sut.RemoveField(terenDeSters.Id);

        Assert.Single(_fakeDatabase); 
        Assert.DoesNotContain(_fakeDatabase, t => t.Id == terenDeSters.Id);

        _mockRepo.Verify(r => r.SalveazaTerenuri(It.IsAny<List<Teren>>()), Times.Once);
    }

    [Fact]
    public void ModifyField_ShouldUpdate_WhenProgramIsValid()
    {
       
        var teren = _fakeDatabase[0]; 
        string programNou = "09:00-23:00";
        
        _sut.ModifyField(teren.Id, "Nume Schimbat", "Fotbal", 20, programNou, "none", 5, 120);
        
        var terenModificat = _fakeDatabase.FirstOrDefault(t => t.Id == teren.Id);
        Assert.Equal("Nume Schimbat", terenModificat.Nume);
        Assert.Equal(programNou, terenModificat.program_de_functionare);
        Assert.Equal(120, terenModificat.durata_standard);
    }

    [Fact]
    public void ModifyField_ShouldUpdate_WhenRestrictionsAreNone()
    {
      
        var teren = _fakeDatabase[0];
       
        
        
        _sut.ModifyField(teren.Id, "Teren Test", "Fotbal", 10, "08:00-22:00", "NONE", 2, 60);

       
        var terenModificat = _fakeDatabase.First(t => t.Id == teren.Id);
        Assert.Equal("NONE", terenModificat.intervale_indisponibile);
       
    }

    [Fact]
    public void ModifyField_ShouldUpdate_WhenRestrictionsAreValidList()
    {
       
        var teren = _fakeDatabase[0];
        string restrictiiNoi = "12:00-13:00, 15:00-16:00"; 
        
        _sut.ModifyField(teren.Id, "Teren Test", "Fotbal", 10, "08:00-22:00", restrictiiNoi, 2, 60);
        
        var terenModificat = _fakeDatabase.First(t => t.Id == teren.Id);
        Assert.Equal(restrictiiNoi, terenModificat.intervale_indisponibile);
    }

    [Fact]
    public void ModifyField_ShouldNOT_Update_WhenProgramIsInvalid()
    {
       
        var teren = _fakeDatabase[0];
        string programInvalid = "25:00-99:00"; 
        
        _sut.ModifyField(teren.Id, "Nume Nou", "Fotbal", 10, programInvalid, "none", 2, 60);
        
        var terenNemodificat = _fakeDatabase.First(t => t.Id == teren.Id);
       
        Assert.Equal("Teren Sintetic Fotbal", "Teren Sintetic Fotbal");
        Assert.NotEqual("Nume Nou", terenNemodificat.Nume);
    }

    [Fact]
    public void ModifyField_ShouldNOT_Update_WhenRestrictionsAreInvalid()
    {
       
        var teren = _fakeDatabase[0];
        
        string programValid = "08:00-22:00";
        string restrictieInvalida = "12:00-13:00, TextAiurea"; 
        
        _sut.ModifyField(teren.Id, "Nume Nou", "Fotbal", 10, programValid, restrictieInvalida, 2, 60);
        
        var terenNemodificat = _fakeDatabase.First(t => t.Id == teren.Id);
        Assert.NotEqual("Nume Nou", terenNemodificat.Nume);
    }
}
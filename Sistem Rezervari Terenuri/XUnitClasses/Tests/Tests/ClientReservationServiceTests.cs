using Microsoft.Extensions.Logging;
using Moq;
using SistemRezervari.CORE.BookingLogic.Services;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace Tests;

public class ClientReservationServiceTests
{
    private readonly Mock<IFileRepository> _mockRepo;
    private readonly Mock<ILogger<ClientReservationService>> _mockLogger;

    public ClientReservationServiceTests()
    {
        _mockRepo = new Mock<IFileRepository>();
        _mockLogger = new Mock<ILogger<ClientReservationService>>();
    }

    [Fact]
    public void MakeReservation_KnownField_CalculatesEndDateCorrectly()
    {
        var fieldId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var startDate = new DateTime(2026, 1, 10, 10, 0, 0); 
        
        var existingField = new Teren
        (
            Id:  fieldId, 
            Nume: "Teren Fotbal Mare",
            TipSport: "Fotbal",
            Capacitate: 22,
            program_de_functionare: "08:00-22:00",
            intervale_indisponibile: "none",
            nr_max_rezervari: 5,
            durata_standard: 90
        );

        _mockRepo.Setup(r => r.IncarcaTerenuri()).Returns(new List<Teren> { existingField });
        _mockRepo.Setup(r => r.IncarcaRezervari()).Returns(new List<Rezervare>()); // Listă goală de rezervări
        
        var service = new ClientReservationService(_mockRepo.Object, _mockLogger.Object);
        
        service.MakeReservation(fieldId, userId, startDate);
        
        var expectedEndDate = startDate.AddMinutes(90); // 11:30

        _mockRepo.Verify(r => r.SalveazaRezervari(It.Is<List<Rezervare>>(list => 
            list.Count == 1 &&
            list[0].TerenId == fieldId &&
            list[0].DataSfarsit == expectedEndDate
        )), Times.Once);
    }

    [Fact]
    public void MakeReservation_UnknownField_SetsDurationToOneHour()
    {
        var unknownFieldId = Guid.NewGuid();
        var startDate = new DateTime(2026, 1, 10, 10, 0, 0);
        
        _mockRepo.Setup(r => r.IncarcaTerenuri()).Returns(new List<Teren>()); 
        _mockRepo.Setup(r => r.IncarcaRezervari()).Returns(new List<Rezervare>());

        var service = new ClientReservationService(_mockRepo.Object, _mockLogger.Object);
        
        service.MakeReservation(unknownFieldId, Guid.NewGuid(), startDate);
        
        var expectedEndDate = startDate.AddMinutes(60);

        _mockRepo.Verify(r => r.SalveazaRezervari(It.Is<List<Rezervare>>(list => 
            list.Count == 1 &&
            list[0].DataSfarsit == expectedEndDate
        )), Times.Once);
    }
    
    [Fact]
    public void MakeReservation_ExistingReservations_ShouldAppendNewReservation()
    {
        var oldReservation = new Rezervare(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now.AddHours(1));
        var existingList = new List<Rezervare> { oldReservation };
        
        _mockRepo.Setup(r => r.IncarcaRezervari()).Returns(existingList);
        _mockRepo.Setup(r => r.IncarcaTerenuri()).Returns(new List<Teren>());

        var service = new ClientReservationService(_mockRepo.Object, _mockLogger.Object);
        
        service.MakeReservation(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now);
        
        _mockRepo.Verify(r => r.SalveazaRezervari(It.Is<List<Rezervare>>(list => 
            list.Count == 2
        )), Times.Once);
    }

}
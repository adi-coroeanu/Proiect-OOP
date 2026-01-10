using Moq;
using Microsoft.Extensions.Logging;
using SistemRezervari.CORE.BookingLogic.Services;
using SistemRezervari.CORE.Interfaces;
using SistemRezervari.CORE.Entities;

namespace Tests
{
    public class FieldCatalogServiceTests
    {
        private readonly Mock<IFileRepository> _mockRepo;
        private readonly Mock<ILogger<FieldCatalogService>> _mockLogger;

        public FieldCatalogServiceTests()
        {
            _mockRepo = new Mock<IFileRepository>();
            _mockLogger = new Mock<ILogger<FieldCatalogService>>();
        }
        
        private FieldCatalogService CreateServiceWithData(List<Teren> fields, List<Rezervare> reservations)
        {
            _mockRepo.Setup(r => r.IncarcaTerenuri()).Returns(fields);
            _mockRepo.Setup(r => r.IncarcaRezervari()).Returns(reservations);

            return new FieldCatalogService(_mockRepo.Object, _mockLogger.Object);
        }
        

        [Fact]
        public void SearchFieldsBySport_WhenSportExists_ShouldReturnFilteredList()
        {
            // Arrange
            var fields = new List<Teren>
            {
                // Constructor: Id, Nume, TipSport, Capacitate, Program, Intervale, NrMax, Durata
                new Teren(Guid.NewGuid(), "Teren 1", "Fotbal", 10, "10:00-22:00", "none", 1, 60),
                new Teren(Guid.NewGuid(), "Teren 2", "Tenis", 2, "10:00-22:00", "none", 1, 60)
            };
            var service = CreateServiceWithData(fields, new List<Rezervare>());

            // Act
            var result = service.SearchFieldsBySport("Fotbal");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Teren 1", result[0].Nume);
        }

        [Fact]
        public void SearchFieldsBySport_WhenSportDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var fields = new List<Teren> 
            { 
                new Teren(Guid.NewGuid(), "Teren 2", "Tenis", 2, "10:00-22:00", "none", 1, 60)
            };
            var service = CreateServiceWithData(fields, new List<Rezervare>());

            // Act
            var result = service.SearchFieldsBySport("Baschet");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void SearchFieldsByDate_ShouldFilterPreviouslyFoundFields()
        {
            // Arrange
            var fieldFullId = Guid.NewGuid();
            var fieldFreeId = Guid.NewGuid();
            var date = new DateTime(2026, 1, 10);

            var fields = new List<Teren>
            {
                // Teren 1: PLIN (Max 1 rezervare, program scurt 10-11)
                new Teren(fieldFullId, "Teren Plin", "Fotbal", 10, "10:00-11:00", "none", 1, 60),
                
                // Teren 2: LIBER
                new Teren(fieldFreeId, "Teren Liber", "Fotbal", 10, "10:00-11:00", "none", 1, 60)
            };

            var reservations = new List<Rezervare>
            {
                // Ocupăm Terenul 1 complet (10:00 - 11:00)
                new Rezervare(Guid.NewGuid(), fieldFullId, Guid.NewGuid(), date.AddHours(10), date.AddHours(11))
            };

            var service = CreateServiceWithData(fields, reservations);

            // Act 
            service.SearchFieldsBySport("Fotbal");
            
            var result = service.SearchFieldsByDate("10/01/2026");

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Teren Liber", result[0].Nume);
        }

        [Fact]
        public void SearchFieldsByDate_CalledWithoutPreviousSearch_ShouldReturnNull()
        {
            var service = CreateServiceWithData(new List<Teren>(), new List<Rezervare>());
            var result = service.SearchFieldsByDate("10/01/2026");
            Assert.Null(result);
        }

        [Fact]
        public void GetAvailableSlots_NoReservations_ShouldGenerateAllSlots()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var fields = new List<Teren>
            {
                // Program 10:00-13:00, 60 min, Max 1 rezervare
                new Teren(fieldId, "Teren Test", "Fotbal", 10, "10:00-13:00", "none", 1, 60)
            };
            
            var service = CreateServiceWithData(fields, new List<Rezervare>());

            // Act
            var slots = service.GetAvailableSlots(fieldId, "10/01/2026");

            // Assert
            Assert.NotNull(slots);
            Assert.Equal(3, slots.Count); // 10-11, 11-12, 12-13
            Assert.Contains("10:00-11:00", slots);
        }

        [Fact]
        public void GetAvailableSlots_WithBlockedPeriods_ShouldExcludeThoseSlots()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var fields = new List<Teren>
            {
                // Program 10-14, Blocat intre 11 si 12
                new Teren(fieldId, "Teren Test", "Fotbal", 10, "10:00-14:00", "11:00, 12:00", 1, 60)
            };
            
            var service = CreateServiceWithData(fields, new List<Rezervare>());

            // Act
            var slots = service.GetAvailableSlots(fieldId, "10/01/2026");

            // Assert
            Assert.NotNull(slots);
            Assert.DoesNotContain("11:00-12:00", slots); // Blocat
            Assert.Contains("10:00-11:00", slots);
            Assert.Contains("13:00-14:00", slots);
        }

        [Fact]
        public void GetAvailableSlots_CapacityLogic_ShouldBlockOnlyIfFull()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var date = new DateTime(2026, 1, 10);
            
            var fields = new List<Teren>
            {
                // Program 10-12, Max 2 rezervari
                new Teren(fieldId, "Teren Test", "Fotbal", 22, "10:00-12:00", "none", 2, 60)
            };
            
            var existingReservations = new List<Rezervare>
            {
                new Rezervare(Guid.NewGuid(), fieldId, Guid.NewGuid(), date.AddHours(10), date.AddHours(11))
            };

            var service = CreateServiceWithData(fields, existingReservations);

            // Act
            var slots = service.GetAvailableSlots(fieldId, "10/01/2026");

            // Assert
            // 1 < 2 => Slotul 10-11 trebuie să fie încă LIBER
            Assert.NotNull(slots);
            Assert.Contains("10:00-11:00", slots);
        }

        [Fact]
        public void GetAvailableSlots_CapacityLogic_ShouldBlockIfCapacityReached()
        {
            // Arrange
            var fieldId = Guid.NewGuid();
            var date = new DateTime(2026, 1, 10);
            
            var fields = new List<Teren>
            {
                // Max 2 rezervari
                new Teren(fieldId, "Teren Test", "Fotbal", 22, "10:00-12:00", "none", 2, 60)
            };

            // Două rezervări existente (FULL)
            var existingReservations = new List<Rezervare>
            {
                new Rezervare(Guid.NewGuid(), fieldId, Guid.NewGuid(), date.AddHours(10), date.AddHours(11)),
                new Rezervare(Guid.NewGuid(), fieldId, Guid.NewGuid(), date.AddHours(10), date.AddHours(11))
            };

            var service = CreateServiceWithData(fields, existingReservations);

            // Act
            var slots = service.GetAvailableSlots(fieldId, "10/01/2026");

            // Assert
            Assert.NotNull(slots);
            Assert.DoesNotContain("10:00-11:00", slots); // Ocupat
            Assert.Contains("11:00-12:00", slots);
        }

        [Fact]
        public void GetAvailableSlots_WhenFieldIdNotFound_ShouldReturnEmptyAndLogWarning()
        {
            // Arrange
            var service = CreateServiceWithData(new List<Teren>(), new List<Rezervare>());

            // Act
            var result = service.GetAvailableSlots(Guid.NewGuid(), "10/01/2026");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            
            _mockLogger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(l => l == LogLevel.Warning),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception?>(),
                    It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true)),
                Times.Once);
        }
    }
}
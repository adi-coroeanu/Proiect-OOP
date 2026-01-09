using Microsoft.Extensions.Logging;
using Moq;
using SistemRezervari.CORE.BookingLogic.Services;
using SistemRezervari.CORE.Entities;
using SistemRezervari.CORE.Interfaces;

namespace Tests;

public class ClientDashboardServiceTests
{
    [Fact]
    public void GetUserReservations_Reservations_ListReservations()
    {
        var targetedUserId = Guid.NewGuid();

        var clientDashboardService = MockedClientDashboardService(targetedUserId);
        
        var result = clientDashboardService.GetUserReservations(targetedUserId);

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetUserReservations_NoReservations_Null()
    {
        var clientDashboardService = MockedClientDashboardService(Guid.NewGuid());
        
        Assert.Null(clientDashboardService.GetUserReservations(Guid.NewGuid()));
    }
    

    private ClientDashboardService MockedClientDashboardService(Guid targetedUserId)
    {
        var mockedReservationList = new List<Rezervare>
        {
            new Rezervare(Guid.NewGuid(), Guid.NewGuid(), targetedUserId, DateTime.Now, DateTime.Now.AddHours(1)),
            new Rezervare(Guid.NewGuid(), Guid.NewGuid(), targetedUserId, DateTime.Now, DateTime.Now.AddHours(1)),
            new Rezervare(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now.AddHours(1)),
            new Rezervare(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, DateTime.Now.AddHours(1))
        };
        
        var mockRepository = new Mock<IFileRepository>();

        var mockLogger = new Mock<ILogger>();
        
        mockRepository.Setup(repo => repo.IncarcaRezervari()).Returns(mockedReservationList);
        
        return new ClientDashboardService(mockRepository.Object, mockLogger.Object);
    }
}

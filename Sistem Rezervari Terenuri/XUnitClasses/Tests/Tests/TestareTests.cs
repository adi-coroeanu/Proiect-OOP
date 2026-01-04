// Test pt Unit Testing

namespace Tests;

using SistemRezervari.CORE.BookingLogic;
using Moq;

public class TestareTests
{
    [Fact]
    public void VarstaAdmisa_VarstaPreaMica_False()
    {
        var mockPers = new Mock<IPersoana>();

        mockPers.Setup(x => x.GetVarsta()).Returns(10);

        var test = new Testare(mockPers.Object);
        
        Assert.False(test.VarstaAdmisa());
    }

    [Fact]
    public void VarstaAdmisa_VarstaBuna_True()
    {
        var mockPers = new Mock<IPersoana>();

        mockPers.Setup(x => x.GetVarsta()).Returns(30);
        
        var test = new Testare(mockPers.Object);
        
        Assert.True(test.VarstaAdmisa());
    }

    [Fact]
    public void VarstaAdmisa_VarstaNeadmisa_Error()
    {
        var mockPers = new Mock<IPersoana>();

        mockPers.Setup(x => x.GetVarsta()).Returns(150);
        
        var test = new Testare(mockPers.Object);

        Assert.Throws<Exception>(() => test.VarstaAdmisa());
    }
}
using Microsoft.Extensions.Configuration;
using Moq;
using SimpleConsoleGame.Extensions;

namespace SimpleConsoleGame.Tests;

public class MapTests
{
    [Fact]
    public void Constructor_SetCorrectWidth_WithIConfig()
    {
        //Arrange
        const int expectedWidth = 10;

        var iconfigMock = new Mock<IConfiguration>();
        var getMapSizeForMock = new Mock<IGetMapSize>();

        getMapSizeForMock.Setup(x => x.GetMapSizeFor(iconfigMock.Object, It.IsAny<string>())).Returns(expectedWidth);
        GetMapSizeForWrapper.Implementation = getMapSizeForMock.Object;

        //Act
        var map = new Map(iconfigMock.Object);

        //Assert
        Assert.Equal(expectedWidth, map.Width);
    }
}

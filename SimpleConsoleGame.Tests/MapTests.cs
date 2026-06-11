using Microsoft.Extensions.Configuration;
using Moq;
using SimpleConsoleGame.Extensions;
using SimpleConsoleGame.Services;
using SimpleConsoleGame.Settings;

namespace SimpleConsoleGame.Tests;

public class MapTests
{
    //[Fact]
    //public void Constructor_SetCorrectWidth_WithIConfig()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;

    //    var iconfigMock = new Mock<IConfiguration>();
    //    var getMapSizeForMock = new Mock<IGetMapSize>();

    //    getMapSizeForMock.Setup(x => x.GetMapSizeFor(iconfigMock.Object, It.IsAny<string>())).Returns(expectedWidth);
    //    GetMapSizeForWrapper.Implementation = getMapSizeForMock.Object;

    //    //Act
    //    var map = new Map(iconfigMock.Object);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    //[Fact]
    //public void Constructor_SetCorrectWidth_WithFunc()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;

    //    var iconfigMock = new Mock<IConfiguration>();
    //    ConfigurationExtensions2.Implementation = (config, key) => expectedWidth;        

    //    //Act
    //    var map = new Map(iconfigMock.Object);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    //[Fact]
    //public void Constructor_SetCorrectWidth_With_MapSettings()
    //{
    //    //Arrange
    //    const int expectedWidth = 10;
    //    var mapsettings = new MapSettings { X = expectedWidth };

    //    //Act
    //    var map = new Map(mapsettings);

    //    //Assert
    //    Assert.Equal(expectedWidth, map.Width);
    //}

    [Fact]
    public void Constructor_SetCorrectWidth_With_GetMapService()
    {
        //Arrange
        const int expectedWidth = 10;
        const int expectedHeight = 10;

        var getMapServiceMock = new Mock<IGetMapService>();
        getMapServiceMock.Setup(x => x.GetMapSize()).Returns((expectedWidth, expectedHeight));

        //Act
        var map = new Map(getMapServiceMock.Object);

        //Assert
        Assert.Equal(expectedWidth, map.Width);
        Assert.Equal(expectedHeight, map.Height);
    }



    //public int Test(IConfiguration config, string key)
    //{

    //    //...
    //    //..
    //    //..
    //    return 10;
    //}
}

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SilosApi.Controllers;
using SilosApi.Dto;
using SilosApi.Services;

namespace Tests;

public class SilosTests
{
    [Fact]
    public async Task GetUserName_ReturnsNameFromService()
    {
        // Arrange
        var mockUserService = new Mock<ISilosService>();
        mockUserService
            .Setup(x => x.GetAllSilosAsync(null))
            .ReturnsAsync(new List<SilosDto>());
    
        var controller = new SilosController(mockUserService.Object);
    
        // Act
        var result = await controller.GetAllSilos(null);
    
        // Assert
        //result.Should().Be(new List<SilosDto>());
        Assert.IsType<OkObjectResult>(result.Result);
        
        mockUserService.Verify(x => x.GetAllSilosAsync(null), Times.Once);  // Проверка, что метод вызван 1 раз
    }
    
    [Fact]
    public async Task GetUserName_ReturnsNameFrom()
    {
        Assert.Equal(1, 1);
    }
}
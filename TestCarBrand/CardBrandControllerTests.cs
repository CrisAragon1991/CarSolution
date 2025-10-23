using CarBrand.Domain.Agregate;
using CarBrand.Presentation.Controllers;
using CardBrand.Application.Commands;
using CardBrand.Application.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class CardBrandControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly CardBrandController _controller;

    public CardBrandControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new CardBrandController(_mediatorMock.Object);
    }

    [Fact]
    public async Task CreateReturnsOkWithCreatedEntity()
    {
        // Arrange
        var command = new CreateCarBrandCommand { Name = "Toyota", Country = "Japan" };
        var createdEntity = new CarBrandEntity
        {
            Id = Guid.NewGuid(),
            Name = "Toyota",
            Country = "Japan"
        };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<CreateCarBrandCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(createdEntity);

        // Act
        var actionResult = await _controller.Create(command);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        var returnedEntity = Assert.IsType<CarBrandEntity>(okResult.Value);
        Assert.Equal(createdEntity.Id, returnedEntity.Id);
        Assert.Equal("Toyota", returnedEntity.Name);
        Assert.Equal("Japan", returnedEntity.Country);
    }



    [Fact]
    public async Task UpdateReturnsOkWhenSuccess()
    {
        var command = new UpdateCarBrandCommand { Id = Guid.NewGuid(), Name = "Updated" };

        _mediatorMock
            .Setup(m => m.Send(It.IsAny<UpdateCarBrandCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true); // Simula éxito

        var result = await _controller.Update(command);

        var okResult = Assert.IsType<OkObjectResult>(result); 
        Assert.NotNull(okResult.Value);                       
        Assert.IsType<bool>(okResult.Value);                  
        Assert.True((bool)okResult.Value);                    
    }

    [Fact]
    public async Task GetAllReturnsOkWithList()
    {
        var mockData = new List<CarBrandEntity>
        {
            new CarBrandEntity { Id = Guid.NewGuid(), Name = "Toyota", Country = "Japan" },
            new CarBrandEntity { Id = Guid.NewGuid(), Name = "Ford", Country = "EEUU" }
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCarBrandQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(mockData);

        var result = await _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(mockData, okResult.Value);
    }

    [Fact]
    public async Task GetByIdReturnsOkWhenFound()
    {
        var id = Guid.NewGuid();
        var brand = new CarBrandEntity { Id = id, Name = "Toyota", Country = "Japan" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCarBrandByIdQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(brand);

        var result = await _controller.GetById(id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(brand, okResult.Value);
    }

    [Fact]
    public async Task DeleteByIdReturnsOk()
    {
        var id = Guid.NewGuid();

        _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteCarBrandCommand>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(true); // Optional: you can assert this if needed

        var result = await _controller.DeleteById(id);

        Assert.IsType<OkResult>(result);
    }
}
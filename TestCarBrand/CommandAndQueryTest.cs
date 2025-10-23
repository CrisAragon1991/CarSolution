using CarBrand.Domain.Agregate;
using CarBrand.Domain.AgregateCardBrand;
using CarBrand.Infraestructure.Context;
using CarBrand.Infraestructure.Repositories;
using CardBrand.Application.Commands;
using CardBrand.Application.Query;
using Microsoft.EntityFrameworkCore;

namespace TestCarBrand
{
    public class CommandAndQueryTest
    {
        private readonly ICarBrandRepository _repository;
        private readonly CarBrandContext _context;
        public CommandAndQueryTest()
        {
            var options = new DbContextOptionsBuilder<CarBrandContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new CarBrandContext(options);
            _repository = new CarBrandRepository(_context);
        }

        [Fact]
        public async Task HandleCreatesEntityInMemoryDb()
        {
            var handler = new CreateCarBrandCommandHandler(_repository);

            var command = new CreateCarBrandCommand
            {
                Name = "Toyota",
                Country = "Japan"
            };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal("Toyota", result.Name);
            Assert.Equal("Japan", result.Country);
            Assert.True(_context.CarBrands.Any(c => c.Name == "Toyota"));
        }

        [Fact]
        public async Task HandleUpdatesEntityInMemoryDb()
        {
             var originalEntity = new CarBrandEntity
            {
                Id = Guid.NewGuid(),
                Name = "Toyota",
                Country = "Japan"
            };
            _context.CarBrands.Add(originalEntity);
            await _context.SaveChangesAsync();

            // Crear handler y comando de actualización
            var handler = new UpdateCarBrandCommandHandler(_repository);
            var command = new UpdateCarBrandCommand
            {
                Id = originalEntity.Id,
                Name = "Toyota Updated",
                Country = "Japan Updated"
            };

            var result = await handler.Handle(command, CancellationToken.None);

            Assert.True(result);

            var updatedEntity = await _context.CarBrands.FindAsync(originalEntity.Id);
            Assert.NotNull(updatedEntity);
            Assert.Equal("Toyota Updated", updatedEntity.Name);
            Assert.Equal("Japan Updated", updatedEntity.Country);
        }

        [Fact]
        public async Task HandleDeletesEntityFromInMemoryDb()
        {
            var entity = new CarBrandEntity
            {
                Id = Guid.NewGuid(),
                Name = "Toyota",
                Country = "Japan"
            };
            _context.CarBrands.Add(entity);
            await _context.SaveChangesAsync();

            var handler = new DeleteCarBrandCommandHandler(_repository);
            var command = new DeleteCarBrandCommand { Id = entity.Id };

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            var deleted = await _context.CarBrands.FindAsync(entity.Id);
            Assert.Null(deleted);
        }

        [Fact]
        public async Task Handle_ReturnsEntity_WhenIdExists()
        {

            var entity = new CarBrandEntity
            {
                Id = Guid.NewGuid(),
                Name = "Toyota",
                Country = "Japan"
            };
            _context.CarBrands.Add(entity);
            await _context.SaveChangesAsync();

            var handler = new GetCarBrandByIdQueryHandler(_repository);
            var query = new GetCarBrandByIdQuery { Id = entity.Id };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity.Id, result.Id);
            Assert.Equal("Toyota", result.Name);
            Assert.Equal("Japan", result.Country);
        }

        [Fact]
        public async Task Handle_ReturnsNull_WhenIdDoesNotExist()
        {
            var handler = new GetCarBrandByIdQueryHandler(_repository);
            var query = new GetCarBrandByIdQuery { Id = Guid.NewGuid() }; // ID no existente

            var result = await handler.Handle(query, CancellationToken.None);

            Assert.Null(result);
        }


        [Fact]
        public async Task Handle_ReturnsAllEntitiesFromInMemoryDb()
        {
            var entities = new List<CarBrandEntity>
            {
                new CarBrandEntity { Id = Guid.NewGuid(), Name = "Toyota", Country = "Japan" },
                new CarBrandEntity { Id = Guid.NewGuid(), Name = "Ford", Country = "USA" },
                new CarBrandEntity { Id = Guid.NewGuid(), Name = "BMW", Country = "Germany" }
            };

            _context.CarBrands.AddRange(entities);
            await _context.SaveChangesAsync();

            var handler = new GetCarBrandQueryHandler(_repository);
            var query = new GetCarBrandQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.All(entities, e => Assert.Contains(result, r => r.Id == e.Id && r.Name == e.Name && r.Country == e.Country));
        }


    }
}

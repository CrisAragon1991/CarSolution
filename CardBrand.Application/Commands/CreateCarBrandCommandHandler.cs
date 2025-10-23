using CarBrand.Domain.Agregate;
using CarBrand.Domain.AgregateCardBrand;
using MediatR;

namespace CardBrand.Application.Commands
{
    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommand, CarBrandEntity>
    { 
        private readonly ICarBrandRepository _repository;
        public CreateCarBrandCommandHandler(ICarBrandRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<CarBrandEntity> Handle(CreateCarBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = new CarBrandEntity
            {
                Name = request.Name,
                Country = request.Country
            };

            return await _repository.CreateAsync(entity);

        }
    }
}

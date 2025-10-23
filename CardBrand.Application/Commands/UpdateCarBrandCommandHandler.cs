using CarBrand.Domain.Agregate;
using CarBrand.Domain.AgregateCardBrand;
using MediatR;

namespace CardBrand.Application.Commands
{
    public class UpdateCarBrandCommandHandler : IRequestHandler<UpdateCarBrandCommand, bool>
    {
        private ICarBrandRepository _repository;

        public UpdateCarBrandCommandHandler(ICarBrandRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(UpdateCarBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(new CarBrandEntity
            {
                Id = request.Id,
                Name = request.Name,
                Country = request.Country
            });
        }
    }
}

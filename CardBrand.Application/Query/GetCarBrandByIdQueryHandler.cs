using CarBrand.Domain.Agregate;
using CarBrand.Domain.AgregateCardBrand;
using MediatR;

namespace CardBrand.Application.Query
{
    public class GetCarBrandByIdQueryHandler : IRequestHandler<GetCarBrandByIdQuery, CarBrandEntity?>
    {
        private ICarBrandRepository _repository;

        public GetCarBrandByIdQueryHandler(ICarBrandRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<CarBrandEntity?> Handle(GetCarBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetByIdAsync(request.Id);
        }
    }
}

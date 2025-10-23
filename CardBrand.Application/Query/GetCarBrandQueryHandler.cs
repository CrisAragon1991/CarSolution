using CarBrand.Domain.Agregate;
using MediatR;
using CarBrand.Domain.AgregateCardBrand;

namespace CardBrand.Application.Query
{
    public class GetCarBrandQueryHandler : IRequestHandler<GetCarBrandQuery, IEnumerable<CarBrandEntity>>
    {
        private readonly ICarBrandRepository _repository;
        public GetCarBrandQueryHandler(ICarBrandRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<IEnumerable<CarBrandEntity>> Handle(GetCarBrandQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}

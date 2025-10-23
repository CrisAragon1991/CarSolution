using CarBrand.Domain.Agregate;
using MediatR;

namespace CardBrand.Application.Query
{
    public class GetCarBrandQuery : IRequest<IEnumerable<CarBrandEntity>>
    {
    }
}

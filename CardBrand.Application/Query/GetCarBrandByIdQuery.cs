using CarBrand.Domain.Agregate;
using MediatR;

namespace CardBrand.Application.Query
{
    public class GetCarBrandByIdQuery : IRequest<CarBrandEntity>
    {
        public Guid Id { get; set; }
    }
}

using MediatR;
using CarBrand.Domain.Agregate;

namespace CardBrand.Application.Commands
{
    public class CreateCarBrandCommand : IRequest<CarBrandEntity>
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}

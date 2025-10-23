using CarBrand.Domain.Agregate;
using MediatR;

namespace CardBrand.Application.Commands
{
    public class UpdateCarBrandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}

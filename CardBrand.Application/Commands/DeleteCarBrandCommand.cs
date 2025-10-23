using MediatR;

namespace CardBrand.Application.Commands
{
    public class DeleteCarBrandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

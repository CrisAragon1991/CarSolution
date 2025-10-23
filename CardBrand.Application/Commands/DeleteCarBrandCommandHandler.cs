using CarBrand.Domain.AgregateCardBrand;
using MediatR;

namespace CardBrand.Application.Commands
{
    public class DeleteCarBrandCommandHandler : IRequestHandler<DeleteCarBrandCommand, bool>
    {
        private ICarBrandRepository _repository;

        public DeleteCarBrandCommandHandler(ICarBrandRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> Handle(DeleteCarBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}

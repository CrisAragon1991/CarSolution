using CarBrand.Domain.Agregate;

namespace CarBrand.Domain.AgregateCardBrand
{
    public interface ICarBrandRepository
    {
        public Task<CarBrandEntity> CreateAsync(CarBrandEntity carBrand);

        public Task<CarBrandEntity?> GetByIdAsync(Guid id);

        public Task<IEnumerable<CarBrandEntity>> GetAllAsync();

        public Task<bool> UpdateAsync(CarBrandEntity carBrand);

        public Task<bool> DeleteAsync(Guid id);

    } 
}

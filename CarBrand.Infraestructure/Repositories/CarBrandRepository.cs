using CarBrand.Domain.Agregate;
using CarBrand.Domain.AgregateCardBrand;
using CarBrand.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBrand.Infraestructure.Repositories
{
    public class CarBrandRepository : ICarBrandRepository
    {
        private readonly CarBrandContext _context;
        public CarBrandRepository(CarBrandContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<CarBrandEntity> CreateAsync(CarBrandEntity carBrand)
        {
            carBrand.Id = Guid.NewGuid();
            await _context.CarBrands.AddAsync(carBrand); 
            await _context.SaveChangesAsync();       
            return carBrand;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _context.CarBrands.FindAsync(id);
            if (existing is null) return false;

            _context.CarBrands.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CarBrandEntity>> GetAllAsync()
        {
            return await _context.CarBrands.ToListAsync();
        }

        public async Task<CarBrandEntity?> GetByIdAsync(Guid id)
        {
            return await _context.CarBrands.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(CarBrandEntity carBrand)
        {
            var existing = await _context.CarBrands.FindAsync(carBrand.Id);
            if (existing is null) return false;

            _context.Entry(existing).CurrentValues.SetValues(carBrand);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

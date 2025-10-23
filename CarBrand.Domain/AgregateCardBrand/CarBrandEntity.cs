namespace CarBrand.Domain.Agregate
{
    public class CarBrandEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}

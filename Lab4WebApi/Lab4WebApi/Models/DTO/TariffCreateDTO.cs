namespace Lab4WebApi.Models.DTO
{
    public class TariffCreateDTO
    {
        public int ServiceId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

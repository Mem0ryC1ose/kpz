namespace Lab4WebApi.Models.DTO
{
    public class TariffUpdateDTO
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}

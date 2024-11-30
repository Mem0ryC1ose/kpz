namespace Lab4WebApi.Models.DTO
{
    public class ServiceCreateDTO
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Type { get; set; } = null!;
    }
}

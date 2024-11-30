namespace Lab4WebApi.Models.DTO
{
    public class ClientCreateDTO
    {
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public DateOnly RegistrationDate { get; set; }
    }
}

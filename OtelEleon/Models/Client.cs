namespace OtelEleon.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public bool? BonusCart { get; set; } = false;
        public Passport? Passport { get; set; }
        public MigrateCart? MigrateCart { get; set; }
        public List<ContractOtel>? ContractOtels { get; set; }
    }
}
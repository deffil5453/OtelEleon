namespace OtelEleon.Models
{
    public class Passport
    {
        public Guid ClientId { get; set; }
        public string Serias { get; set; }
        public string Number { get; set; }
        public string TypeDocument { get; set; }
        public DateOnly DateIssued { get; set; }
        public string Adress { get; set; }
        public string Country { get; set; }
        public Client? Client { get; set; }
    }
}

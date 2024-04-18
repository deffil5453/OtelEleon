namespace OtelEleon.Models
{
    public class MigrateCart
    {
        public Guid ClientId { get; set; }
        public string Number { get; set; }
        public string CountryWhereFrom {  get; set; }
        public string StayWith { get; set;}
        public string StayUntil { get; set; }
        public string PurposeTrip { get; set; }
        public Client? Client {  get; set; } 
    }
}
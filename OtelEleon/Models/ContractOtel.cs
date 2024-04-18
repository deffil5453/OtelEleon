namespace OtelEleon.Models
{
    public class ContractOtel
    {
        public Guid Id { get; set; }
        public DateTime DateCreateContract { get; set; }
        public DateOnly DateArrival {  get; set; }
        public DateOnly DateDeparture { get; set; }
        public int PaymentAmount { get; set; } =0;
        public string PaymentType { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public short RoomOtelId { get; set; }
        public RoomOtel RoomOtel { get; set; }
    }
}
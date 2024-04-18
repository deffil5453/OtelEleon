using Microsoft.EntityFrameworkCore;

namespace OtelEleon.Models
{
    [PrimaryKey(nameof(RoomOtelNumber))]
    public class RoomOtel
    {
        public short RoomOtelNumber { get; set; }
        public string Description { get; set; }
        public string Floor { get; set; }
        public int PricePerDay { get; set; }
        public byte MumberSeats { get; set; }
        public string Status { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ContractOtel>? ContractOtels { get; set; }
    }
}
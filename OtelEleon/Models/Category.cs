using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OtelEleon.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<RoomOtel>? RoomOtels { get; set; }
    }
}
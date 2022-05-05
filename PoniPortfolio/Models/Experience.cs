using System.ComponentModel.DataAnnotations;

namespace PoniPortfolio.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string? Role { get; set; }
        public string? Company { get; set; }
        public string? Duration { get; set; }
        public string? Description { get; set; }
        public bool IsFeatured { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

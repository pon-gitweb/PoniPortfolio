using System.ComponentModel.DataAnnotations;

namespace PoniPortfolio.Models
{
    public class Media
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Source { get; set; }
        public string? ThumbNail { get; set; }
        public bool IsFeatured { get; set; }

        [Required]
        public string? Decsription { get; set; }

        public string? Tags { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}

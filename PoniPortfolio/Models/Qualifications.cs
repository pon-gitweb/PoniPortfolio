using System.ComponentModel.DataAnnotations;

namespace PoniPortfolio.Models
{
    public class Qualifications
    {
        public int Id { get; set; }
        public string? Qualification { get; set; }
        public string? Major { get; set; }
        public string? Institution { get; set; }
        public bool IsFeatured { get; set; }

        [DataType(DataType.Date)]
        public DateTime Completed { get; set; }
    }
}

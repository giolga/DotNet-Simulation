using System.ComponentModel.DataAnnotations;

namespace LastFinal.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public ICollection<InsuranceProduct> InsuranceProduct { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LastFinal.Model
{
    public class Package
    {
        [Key]
        public int PackageId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<InsuranceProduct> InsuranceProduct { get; set; }
    }
}

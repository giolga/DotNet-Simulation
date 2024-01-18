using System.ComponentModel.DataAnnotations;

namespace LastFinal.Model
{
    public class InsuranceProduct
    {
        [Key] 
        public int InsuranceId { get; set; }
        [Required, MinLength(2), MaxLength(20)]
        public string InsuranceName { get; set; }
        public int CategoryId { get; set; } 
        public Category Categorie { get; set; }
        public int TypeId { get; set; }
        public Typee Typee { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public int AuthorizedId { get; set; }
        public AuthorizedUser AuthorizedUser { get; set; }
        public string Description { get; set; }
        [Required]
        public int Premium { get; set; }
        public ICollection<User> User { get; set; }
    }
}

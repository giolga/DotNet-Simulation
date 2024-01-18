using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LastFinal.Model
{
    public class AuthorizedUser
    {
        [Key]
        public int AuthorizedId { get; set; }
        [Required]
        public string AuthorizedName { get; set; }
        public ICollection<InsuranceProduct> InsuranceProduct { get; set; }
    }
}

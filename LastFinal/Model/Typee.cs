using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LastFinal.Model
{
    public class Typee
    {
        [Key]
        public int TypeId { get; set; }
        [Required]
        public string TypeName { get; set; }
        [JsonIgnore]
        public ICollection<InsuranceProduct> InsuranceProducts { get; set; }
    }
}

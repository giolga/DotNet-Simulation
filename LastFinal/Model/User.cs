using System.ComponentModel.DataAnnotations;

namespace LastFinal.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required] 
        public string UserName { get; set;}
        [Required]
        public string UserLastName { get; set;}

        public int ProductId { get; set;}
        public ICollection<InsuranceProduct> InsuranceProduct { get; set;}
    }
}

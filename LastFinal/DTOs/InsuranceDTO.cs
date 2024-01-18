using LastFinal.Model;

namespace LastFinal.DTOs
{
    public class InsuranceDTO
    {
        public string InsuranceName { get; set; }
        public string CategoryName { get; set; }
        public string TypeName { get; set; }
        public string PackageName { get; set; }
        public string AuthorizedName { get; set; }
        public string Description { get; set; }
        public int Premium { get; set; }
    }
    public class InsuranceDTOId : InsuranceDTO {
        public int InsuranceIdDto { get; set; }
    }
}

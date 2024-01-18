namespace LastFinal.DTOs
{
    public class AuthorizedDTO
    {
        public string AuthorizedName { get; set; }
    }
    public class AuthorizedDTOId : AuthorizedDTO {
        public int AuthorizedIdDto { get; set; }
    }

}

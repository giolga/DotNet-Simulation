using System.ComponentModel.DataAnnotations;

namespace LastFinal.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string ProductName { get; set; }
    }
    public class UserDTOId : UserDTO {
        public int UserIdDto { get; set; }
    }
}

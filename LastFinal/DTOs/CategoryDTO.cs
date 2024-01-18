namespace LastFinal.DTOs
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }
    }
    public class CategoryDTOId : CategoryDTO {
        public int CategoryIdDto { get; set; }
    }
}

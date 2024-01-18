namespace LastFinal.DTOs
{
    public class PackageDTO
    {
        public string Name { get; set; }
    }
    public class PackageDTOId : PackageDTO {
        public int PackageIdDto { get; set; }
    }
}

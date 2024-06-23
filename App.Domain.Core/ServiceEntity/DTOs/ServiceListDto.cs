namespace App.Domain.Core.ServiceEntity.DTOs
{
    public class ServiceListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? PictureLocation { get; set; }
        public string CategoryTitle { get; set; }
        public string Description { get; set; }
    }
}

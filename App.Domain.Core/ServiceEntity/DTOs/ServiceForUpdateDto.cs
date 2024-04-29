namespace App.Domain.Core.ServiceEntity.DTOs
{
    public class ServiceForUpdateDto
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}

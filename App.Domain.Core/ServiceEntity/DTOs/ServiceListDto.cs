namespace App.Domain.Core.ServiceEntity.DTOs
{
    public class ServiceListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int ExpertCount { get; set; }
        public int RequestCount { get; set; }
    }
}

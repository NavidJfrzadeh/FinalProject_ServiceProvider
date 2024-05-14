namespace App.Domain.Core.CommentEntity.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string CustomerName { get; set; }
        public string ExpertName { get; set; }
        public decimal Score { get; set; }
        public bool IsAccepted { get; set; }
        public string Description { get; set; }
    }
}

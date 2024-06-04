namespace App.Domain.Core.CommentEntity.DTOs
{
    public class ExpertCommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? CustomerImage { get; set; }
        public string CustomerFullName { get; set; }
        public decimal Score { get; set; }
        public string Description { get; set; }
        public string CreatedAtFa { get; set; }
    }
}

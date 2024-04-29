using App.Domain.Core.CommentEntity.DTOs;

namespace App.Domain.Core.CommentEntity.Contracts
{
    public interface ICommentRepository
    {
        public bool Create(Comment newComment);
        public List<ExpertCommentDto> GetForExpert(int expertId);
    }
}

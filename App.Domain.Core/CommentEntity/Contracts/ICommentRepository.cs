using App.Domain.Core.CommentEntity.DTOs;

namespace App.Domain.Core.CommentEntity.Contracts
{
    public interface ICommentRepository
    {
        public Task< bool> Create(Comment newComment,CancellationToken cancellationToken);
        public Task<List<ExpertCommentDto>> GetForExpert(int expertId,CancellationToken cancellationToken);
    }
}

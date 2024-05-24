using App.Domain.Core.CommentEntity.DTOs;

namespace App.Domain.Core.CommentEntity.Contracts
{
    public interface ICommentAppService
    {
        public Task<bool> Create(CreateCommentDto newCommentDto, CancellationToken cancellationToken);
        public Task<List<ExpertCommentDto>> GetForExpert(int expertId, CancellationToken cancellationToken);
        public Task<List<CommentDto>> GetUnAcceptedComments(CancellationToken cancellationToken);
        public Task<int> GetUnAcceptedCommentsCount(CancellationToken cancellationToken);
        public Task Accept(int id, CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);
        public Task<CommentDto> GetById(int id, CancellationToken cancellationToken);
    }
}

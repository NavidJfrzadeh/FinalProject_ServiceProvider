using App.Domain.Core.CommentEntity;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;

namespace App.Domain.AppService
{
    public class CommentAppService : ICommentAppService
    {
        #region Fields
        private readonly ICommentService _commentService;
        #endregion

        #region Ctors
        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(CreateCommentDto newCommentDto, CancellationToken cancellationToken)
            => await _commentService.Create(newCommentDto, cancellationToken);

        public Task Delete(int id, CancellationToken cancellationToken)
            => _commentService.Delete(id, cancellationToken);

        public Task Accept(int id, CancellationToken cancellationToken)
            => _commentService.Accept(id, cancellationToken);

        public async Task<List<ExpertCommentDto>> GetForExpert(int expertId, CancellationToken cancellationToken)
            => await _commentService.GetForExpert(expertId, cancellationToken);

        public async Task<List<CommentDto>> GetUnAcceptedComments(CancellationToken cancellationToken)
            => await _commentService.GetUnAcceptedComments(cancellationToken);

        public async Task<int> GetUnAcceptedCommentsCount(CancellationToken cancellationToken)
            => await _commentService.GetUnAcceptedCommentsCount(cancellationToken);

        public async Task<CommentDto> GetById(int id, CancellationToken cancellationToken)
            => await _commentService.GetById(id, cancellationToken);
        #endregion
    }
}

using App.Domain.Core.CommentEntity;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;
using App.Domain.Core.RequestEntity.Contracts;

namespace App.Domain.AppService
{
    public class CommentAppService : ICommentAppService
    {
        #region Fields
        private readonly ICommentService _commentService;
        private readonly IRequestService _requestService;
        #endregion

        #region Ctors
        public CommentAppService(ICommentService commentService, IRequestService requestService)
        {
            _commentService = commentService;
            _requestService = requestService;
        }
        #endregion

        #region Implementations
        public async Task Create(CreateCommentDto newCommentDto, CancellationToken cancellationToken)
        {
            var commentId = await _commentService.Create(newCommentDto, cancellationToken);
            await _requestService.SetComment(newCommentDto.RequestId, commentId, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
            => await _commentService.Delete(id, cancellationToken);

        public async Task Accept(int id, CancellationToken cancellationToken)
            => await _commentService.Accept(id, cancellationToken);

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

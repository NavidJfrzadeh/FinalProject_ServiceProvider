﻿using App.Domain.Core.CommentEntity;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;

namespace App.Domain.Service
{
    public class CommentService : ICommentService
    {
        #region Fields
        private readonly ICommentRepository _commentRepository;
        #endregion

        #region Ctors
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(Comment newComment, CancellationToken cancellationToken)
            => await _commentRepository.Create(newComment, cancellationToken);

        public Task Delete(int id, CancellationToken cancellationToken)
            => _commentRepository.Delete(id, cancellationToken);

        public Task Accept(int id, CancellationToken cancellationToken)
            => _commentRepository.Accept(id, cancellationToken);

        public async Task<List<ExpertCommentDto>> GetForExpert(int expertId, CancellationToken cancellationToken)
            => await _commentRepository.GetForExpert(expertId, cancellationToken);

        public async Task<List<CommentDto>> GetUnAcceptedComments(CancellationToken cancellationToken)
            => await _commentRepository.GetUnAcceptedComments(cancellationToken);

        public async Task<int> GetUnAcceptedCommentsCount(CancellationToken cancellationToken)
            => await _commentRepository.GetUnAcceptedCommentsCount(cancellationToken);

        public Task<CommentDto> GetById(int id, CancellationToken cancellationToken)
            => _commentRepository.GetById(id, cancellationToken);
        #endregion
    }
}
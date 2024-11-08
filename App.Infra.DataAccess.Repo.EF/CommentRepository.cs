﻿using App.Domain.Core.CommentEntity;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CommentRepository : ICommentRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;
        #endregion

        #region ctors
        public CommentRepository(AppDbContext Context, IMemoryCache memoryCache)
        {
            _context = Context;
            _memoryCache = memoryCache;
        }
        #endregion

        #region Implementations
        public async Task<int> Create(CreateCommentDto newCommentDto, CancellationToken cancellationToken)
        {
            var newComment = new Comment()
            {
                Title = newCommentDto.Title,
                CustomerId = newCommentDto.CustomerId,
                ExpertId = newCommentDto.ExpertId,
                RequestId = newCommentDto.RequestId,
                Score = newCommentDto.Score,
                Description = newCommentDto.Description
            };
            await _context.Comments.AddAsync(newComment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return newComment.Id;
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var comment = await FindById(id, cancellationToken);
            comment.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Accept(int id, CancellationToken cancellationToken)
        {
            var comment = await FindById(id, cancellationToken);
            comment.IsAccepted = true;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ExpertCommentDto>> GetForExpert(int expertId, CancellationToken cancellationToken)
        {
            var comments = await _context.Comments.AsNoTracking().Where(c => c.ExpertId == expertId && c.IsAccepted == true)
                .Select(c => new ExpertCommentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Score = c.Score,
                    CreatedAtFa = c.CreatedAt.ToPersianString("yyyy/MM/dd"),
                    CustomerFullName = c.Customer.ApplicationUser.FullName,
                    CustomerImage = c.Customer.ProfileImageUrl,
                    Description = c.Description
                }).ToListAsync(cancellationToken);

            return comments;
        }

        public async Task<List<CommentDto>> GetUnAcceptedComments(CancellationToken cancellationToken)
        {
            var comments = await _context.Comments.Where(c => !c.IsAccepted).Select(c => new CommentDto
            {
                CommentId = c.Id,
                Title = c.Title,
                CustomerName = c.Customer.FullName,
                ExpertName = c.Expert.FullName,
                Score = c.Score,
                IsAccepted = c.IsAccepted
            }).ToListAsync(cancellationToken);

            return comments;
        }

        public async Task<int> GetUnAcceptedCommentsCount(CancellationToken cancellationToken)
        {
            try
            {
                var count = await _context.Comments.AsNoTracking().Where(c => !c.IsAccepted).CountAsync(cancellationToken);
                return count;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<CommentDto> GetById(int id, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.Where(c => !c.IsAccepted && c.Id == id).Select(c => new CommentDto
            {
                CommentId = c.Id,
                Title = c.Title,
                CustomerName = c.Customer.FullName,
                ExpertName = c.Expert.FullName,
                Score = c.Score,
                Description = c.Description,
                IsAccepted = c.IsAccepted
            }).FirstOrDefaultAsync(cancellationToken);

            return comment;
        }
        #endregion

        #region Private Methods
        private async Task<Comment> FindById(int commentId, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == commentId, cancellationToken);
            return comment ?? throw new Exception($"Comment with Id {commentId} not found");
        }
        #endregion
    }
}

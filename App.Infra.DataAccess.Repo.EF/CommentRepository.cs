using App.Domain.Core.CommentEntity;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CommentRepository : ICommentRepository
    {
        #region Fields
        private readonly AppDbContext context;
        #endregion

        #region ctors
        public CommentRepository(AppDbContext Context)
        {
            context = Context;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(Comment newComment, CancellationToken cancellationToken)
        {
            await context.Comments.AddAsync(newComment, cancellationToken);
            context.SaveChanges();
            return true;
        }

        public async Task<List<ExpertCommentDto>> GetForExpert(int expertId, CancellationToken cancellationToken)
        {
            var comments = await context.Comments.AsNoTracking().Where(c => c.ExpertId == expertId)
                .Select(c => new ExpertCommentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Score = c.Score,
                    CreatedAt = c.CreatedAt,
                    CustomerFullName = c.Customer.FullName,
                    Description = c.Description
                }).ToListAsync(cancellationToken);
            return comments;
        }
        #endregion

        #region Private Methods\
        private async Task<Comment> FindById(int id, CancellationToken cancellationToken)
        {
            var comment = await context.Comments.FindAsync(id, cancellationToken);
            if (comment != null)
            {
                return comment;
            }
            throw new Exception($"Comment with Id {id} not found");
        }
        #endregion
    }
}

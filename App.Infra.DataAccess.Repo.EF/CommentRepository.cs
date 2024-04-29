using App.Domain.Core.CommentEntity;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;
using App.Infra.DB.SQLServer.EF;

namespace App.Infra.DataAccess.Repo.EF
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext context;

        public CommentRepository(AppDbContext Context)
        {
            context = Context;
        }
        public bool Create(Comment newComment)
        {
            context.Comments.Add(newComment);
            context.SaveChanges();
            return true;
        }

        public List<ExpertCommentDto> GetForExpert(int expertId)
        {
            var comments = context.Comments.Where(c => c.ExpertId == expertId)
                .Select(c => new ExpertCommentDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Score = c.Score,
                    CreatedAt = c.CreatedAt,
                    CustomerFullName = c.Customer.FullName,
                    Description = c.Description
                }).ToList();
            return comments;
        }
    }
}

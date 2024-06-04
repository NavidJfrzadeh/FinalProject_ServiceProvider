using App.Domain.Core.CategoryEntity;
using App.Domain.Core.CategoryEntity.DTOs;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.ExpertEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class ExpertRepository : IExpertRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region ctors
        public ExpertRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
        {
            var Experts = await _context.Experts.AsNoTracking().ToListAsync(cancellationToken);
            if (Experts.Any())
            {
                return Experts;
            }
            return new List<Expert>();
        }

        public async Task<List<int>> GetExpertCategories(int expertId, CancellationToken cancellationToken)
        {
            //var expert = await _context.Experts.Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id == expertId, cancellationToken);
            //if (expert != null)
            //{
            //    var expertCategoryIds = expert.Categories.Select(c => c.Id).ToList();
            //    return expertCategoryIds;
            //}
            //return new List<int>();

            var expertCategoryIds = await _context.Experts.Where(e => e.Id == expertId)
                .SelectMany(e => e.Categories)
                .Select(c => c.Id).ToListAsync(cancellationToken);

            return expertCategoryIds ?? new List<int>();

        }

        public async Task<ExpertSummaryDto> GetSummary(int expertId, CancellationToken cancellationToken)
        {
            var expertSummary = await _context.Experts.Where(e => e.Id == expertId).Select(e => new ExpertSummaryDto
            {
                ExpertId = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.ApplicationUser.Email,
                PhoneNumber = e.ApplicationUser.PhoneNumber,
                ImageAddress = e.ProfileImageUrl,
                CategoryIds = e.Categories.Select(c => c.Id).ToList()
            }).FirstOrDefaultAsync(cancellationToken);

            return expertSummary ?? throw new Exception($"Expert with Id : {expertId} not found!");
        }

        public async Task Update(ExpertSummaryDto expertSummaryDto, CancellationToken cancellationToken)
        {
            //var expert = await FindById(expertSummaryDto.ExpertId, cancellationToken);
            var expert = await _context.Experts.Include(e => e.ApplicationUser).Include(e =>e.Categories)
                .FirstOrDefaultAsync(e => e.Id == expertSummaryDto.ExpertId);

            if (expert != null)
            {
                expert.Categories ??= new List<Category>();


                expert.Categories.Clear();

                if (expertSummaryDto.CategoryIds is not null)
                {
                    foreach (var catId in expertSummaryDto.CategoryIds)
                    {
                        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == catId);
                        expert.Categories.Add(category);
                    }
                }

                expert.FirstName = expertSummaryDto.FirstName;
                expert.LastName = expertSummaryDto.LastName;
                expert.ApplicationUser.Email = expertSummaryDto.Email;
                expert.ApplicationUser.PhoneNumber = expertSummaryDto.PhoneNumber;
                expert.ProfileImageUrl = expertSummaryDto.ImageAddress;

                await _context.SaveChangesAsync(cancellationToken);
            }

            else
                throw new Exception($"Expert with Id {expertSummaryDto.ExpertId} not found");
        }
        #endregion
    }
}

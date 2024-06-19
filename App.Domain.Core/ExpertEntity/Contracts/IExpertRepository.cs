using App.Domain.Core.CategoryEntity.DTOs;
using App.Domain.Core.ExpertEntity.DTOs;

namespace App.Domain.Core.ExpertEntity.Contracts
{
    public interface IExpertRepository
    {
        public Task<ExpertSummaryDto> GetSummary(int ExpertId, CancellationToken cancellationToken);
        public Task<List<ExpertListDto>> GetAll(CancellationToken cancellationToken);
        public Task Update(ExpertSummaryDto expertSummaryDto, CancellationToken cancellationToken);
        public Task<List<int>> GetExpertCategories(int expertId, CancellationToken cancellationToken);
    }
}

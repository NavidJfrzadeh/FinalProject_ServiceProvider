using App.Domain.Core.ExpertEntity.DTOs;

namespace App.Domain.Core.ExpertEntity.Contracts;

public interface IExpertService
{
    public Task<ExpertSummaryDto> GetSummary(int ExpertId, CancellationToken cancellationToken);
    public Task<List<Expert>> GetAll(CancellationToken cancellationToken);
    public Task Update(ExpertSummaryDto expertSummaryDto, CancellationToken cancellationToken);
    public Task<List<int>> GetExpertCategories(int expertId, CancellationToken cancellationToken);
}

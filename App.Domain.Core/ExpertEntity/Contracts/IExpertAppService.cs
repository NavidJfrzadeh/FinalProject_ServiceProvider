using App.Domain.Core.ExpertEntity.DTOs;
using Microsoft.AspNetCore.Http;

namespace App.Domain.Core.ExpertEntity.Contracts;

public interface IExpertAppService
{
    public Task<ExpertSummaryDto> GetSummary(int ExpertId, CancellationToken cancellationToken);
    public Task<List<Expert>> GetAll(CancellationToken cancellationToken);
    public Task Update(ExpertSummaryDto expertSummaryDto, IFormFile formFile, CancellationToken cancellationToken);
    public Task<List<int>> GetExpertCategories(int expertId, CancellationToken cancellationToken);
}

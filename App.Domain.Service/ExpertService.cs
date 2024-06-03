using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.ExpertEntity.DTOs;

namespace App.Domain.Service;

public class ExpertService : IExpertService
{
    #region Fields
    private readonly IExpertRepository _expertRepository;
    #endregion

    #region Ctors
    public ExpertService(IExpertRepository expertReposotory)
    {
        _expertRepository = expertReposotory;
    }
    #endregion

    #region Implementaions
    public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
        => await _expertRepository.GetAll(cancellationToken);

    public async Task<List<int>> GetExpertCategories(int expertId, CancellationToken cancellationToken)
        => await _expertRepository.GetExpertCategories(expertId, cancellationToken);

    public async Task<ExpertSummaryDto> GetSummary(int ExpertId, CancellationToken cancellationToken)
        => await _expertRepository.GetSummary(ExpertId, cancellationToken);

    public async Task Update(ExpertSummaryDto expertSummaryDto, CancellationToken cancellationToken)
        => await _expertRepository.Update(expertSummaryDto, cancellationToken);
    #endregion
}

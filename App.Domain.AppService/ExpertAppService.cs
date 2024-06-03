using App.Domain.Core._3_BaseServices;
using App.Domain.Core.ExpertEntity;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.ExpertEntity.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace App.Domain.AppService;

public class ExpertAppService : IExpertAppService
{
    #region Fields
    private readonly IExpertService _expertService;
    #endregion

    #region Ctors
    public ExpertAppService(IExpertService expertService)
    {
        _expertService = expertService;
    }
    #endregion

    public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
        => await _expertService.GetAll(cancellationToken);

    public async Task<List<int>> GetExpertCategories(int expertId, CancellationToken cancellationToken)
        => await _expertService.GetExpertCategories(expertId, cancellationToken);

    public async Task<ExpertSummaryDto> GetSummary(int ExpertId, CancellationToken cancellationToken)
        => await _expertService.GetSummary(ExpertId, cancellationToken);

    public async Task Update(ExpertSummaryDto expertSummaryDto, IFormFile formFile, CancellationToken cancellationToken)
    {
        var imageAddress = formFile.SaveFileAsync();
        expertSummaryDto.ImageAddress = imageAddress;

        await _expertService.Update(expertSummaryDto, cancellationToken);
    }
}

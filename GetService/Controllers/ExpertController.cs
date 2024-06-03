using App.Domain.Core.BidEntity.DTOs;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.ExpertEntity.DTOs;
using App.Domain.Core.RequestEntity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetService.Controllers
{
    [Authorize(Roles = "Expert")]
    public class ExpertController : Controller
    {
        #region Fields
        private readonly IExpertAppService _expertAppService;
        private readonly IRequestAppService _requestAppService;
        #endregion

        #region Ctors
        public ExpertController(IExpertAppService expertAppService
            , IRequestAppService requestAppService)
        {
            _expertAppService = expertAppService;
            _requestAppService = requestAppService;
        }
        #endregion

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProfileEdit(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.First().Value);
            var expertSummary = await _expertAppService.GetSummary(expertId, cancellationToken);
            return View(expertSummary);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(ExpertSummaryDto expertSummaryDto, IFormFile formFile, CancellationToken cancellationToken)
        {
            await _expertAppService.Update(expertSummaryDto, formFile, cancellationToken);
            return View();
        }

        public async Task<IActionResult> GetRequests(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.First().Value);
            var categoryRequests = await _requestAppService.GetForCategory(expertId, cancellationToken);
            return View(categoryRequests);
        }

        public async Task<IActionResult> GetRequestDetails(CancellationToken cancellationToken)
        {
            return View();
        }

        public IActionResult GetFinishedRequests()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateBid(CancellationToken cancellationToken)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBid(CreateBidDto createBidDto, CancellationToken cancellationToken)
        {
            return View();
        }
    }
}

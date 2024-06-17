using App.Domain.Core;
using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.ExpertEntity.Contracts;
using App.Domain.Core.ExpertEntity.DTOs;
using App.Domain.Core.RequestEntity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetService.Controllers
{
    [Authorize(Roles = "Expert")]
    public class ExpertController : Controller
    {
        #region Fields
        private readonly IExpertAppService _expertAppService;
        private readonly IRequestAppService _requestAppService;
        private readonly IBidAppService _bidAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Ctors
        public ExpertController(IExpertAppService expertAppService
            , IRequestAppService requestAppService
            , IBidAppService bidAppService
            , UserManager<ApplicationUser> userManager
            , ICommentAppService commentAppService)
        {
            _expertAppService = expertAppService;
            _requestAppService = requestAppService;
            _bidAppService = bidAppService;
            _commentAppService = commentAppService;
            _userManager = userManager;
        }
        #endregion

        public async Task<IActionResult> Dashboard()
        {
            var Expert = await _userManager.GetUserAsync(User);
            ViewData["expertName"] = Expert.FullName;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProfileEdit(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
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
            var expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
            ViewData["expertId"] = expertId;
            var categoryRequests = await _requestAppService.GetRequestsForExpert(expertId, cancellationToken);
            return View(categoryRequests);
        }

        public async Task<IActionResult> GetRequestDetails(int requestId, CancellationToken cancellationToken)
        {
            //var reqeust = 
            return View();
        }

        public IActionResult GetFinishedRequests(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
            var finishedRequests = _requestAppService.GetFinishedReqeustsForExpert(expertId, cancellationToken);
            return View(finishedRequests);
        }

        [HttpGet]
        public async Task<IActionResult> BidCreate(int requestId, CancellationToken cancellationToken)
        {
            ViewData["requestId"] = requestId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BidCreate(CreateBidDto createBidDto, CancellationToken cancellationToken)
        {
            var isCreated = await _bidAppService.Create(createBidDto, cancellationToken);
            if (isCreated)
            {
                await _requestAppService.SetRequestStatus(createBidDto.RequestId, Status.WaitingForChoosingExpert, cancellationToken);
            }
            return RedirectToAction("GetRequests");
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
            var comments = await _commentAppService.GetForExpert(expertId, cancellationToken);
            return View(comments);
        }
    }
}

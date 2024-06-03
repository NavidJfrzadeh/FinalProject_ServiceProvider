using App.Domain.Core;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.CommentEntity.DTOs;
using App.Domain.Core.CustomerEntity.Contracts;
using App.Domain.Core.CustomerEntity.DTOs;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetService.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomerController : Controller
    {
        [TempData]
        public string ActiveLink { get; set; }

        private readonly IRequestAppService _requestAppService;
        private readonly IBidAppService _bidAppService;
        private readonly ICommentAppService _commentAppSerivce;
        private readonly ICustomerAppService _customerAppSerivce;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CustomerController(IRequestAppService requestAppService,
            IBidAppService bidAppService,
            ICommentAppService commentAppService,
            ICustomerAppService customerAppService,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _requestAppService = requestAppService;
            _bidAppService = bidAppService;
            _commentAppSerivce = commentAppService;
            _customerAppSerivce = customerAppService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Dashboard(CancellationToken cancellationToken)
        {
            ActiveLink = "Active";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProfileEdit(CancellationToken cancellationToken)
        {
            ActiveLink = "Active";

            //var userId = int.Parse(User.Claims.First().Value);
            var userId = int.Parse(_signInManager.UserManager.GetUserId(User));
            var customerSummary = await _customerAppSerivce.GetCustomerSummary(userId, cancellationToken);
            return View(customerSummary);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(CustomerSummaryDto customerSummary, CancellationToken cancellationToken)
        {
            await _customerAppSerivce.UpdateProfile(customerSummary, cancellationToken);
            return View();
        }

        public async Task<IActionResult> CreateRequest(int id, CancellationToken cancellationToken)
        {
            var newRequestDto = new CreateRequestDto
            {
                ServiceId = id,
                CustomerId = int.Parse(User.Claims.First().Value)
            };

            return View(newRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestDto createRequestDto, CancellationToken cancellationToken)
        {
            var result = await _requestAppService.Create(createRequestDto, cancellationToken);

            if (result)
            {
                TempData["RequestCreated"] = "درخواست شما با موفقیت ثبت شد";
                return RedirectToAction("ServiceDetails", "Home", new { serviceId = createRequestDto.ServiceId, cancellationToken });
            }

            TempData["RequestFailed"] = "ثبت درخواست شما ناموفق بود";
            return RedirectToAction("ServiceDetails", "Home", new { serviceId = createRequestDto.ServiceId, cancellationToken });
        }

        [HttpGet]
        public async Task<IActionResult> RequestList(CancellationToken cancellationToken)
        {
            ActiveLink = "Active";

            var customerId = int.Parse(User.Claims.First().Value);

            var CustomerRequests = await _requestAppService.GetCustomerRequests(customerId, cancellationToken);

            return View(CustomerRequests);
        }


        [HttpGet]
        public async Task<IActionResult> GetRequestBids(int requestId, CancellationToken cancellationToken)
        {
            TempData["requestId"] = requestId;

            var bids = await _bidAppService.GetForRequest(requestId, cancellationToken);
            return View(bids);
        }


        [HttpGet]
        public async Task<IActionResult> GetExpertComments(int expertId, CancellationToken cancellationToken)
        {
            var expertComments = await _commentAppSerivce.GetForExpert(expertId, cancellationToken);
            return View(expertComments);
        }


        [HttpGet]
        public async Task<IActionResult> AccesptBid(int bidId, CancellationToken cancellationToken)
        {
            var result = await _bidAppService.AcceptBid(bidId, cancellationToken);

            if (result)
            {
                int requestId = (int)TempData["requestId"];
                await _requestAppService.SetRequestStatus(requestId, App.Domain.Core._0_BaseEntities.Enums.Status.level3, cancellationToken);
            }
            return RedirectToAction("RequestList");
        }

        [HttpGet]
        public IActionResult WriteCommentForExpert(int expertId)
        {
            var newCommentDto = new CreateCommentDto
            {
                CustomerId = int.Parse(User.Claims.First().Value),
                ExpertId = expertId
            };
            return View(newCommentDto);
        }

        [HttpPost]
        public async Task<IActionResult> WriteCommentForExpert(CreateCommentDto newCommentDto, CancellationToken cancellationToken)
        {
            await _commentAppSerivce.Create(newCommentDto, cancellationToken);
            return RedirectToAction("RequestList");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveRequest(int id, CancellationToken cancellationToken)
        {
            return RedirectToAction("RequestList");
        }
    }
}

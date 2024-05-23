using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.CommentEntity.Contracts;
using App.Domain.Core.RequestEntity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetService.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IRequestAppService _requestAppService;
        private readonly IBidAppService _bidAppService;
        private readonly ICommentAppService _commentAppSerivce;

        public CustomerController(IRequestAppService requestAppService,
            IBidAppService bidAppService,
            ICommentAppService commentAppService
            )
        {
            _requestAppService = requestAppService;
            _bidAppService = bidAppService;
            _commentAppSerivce = commentAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RequestList(CancellationToken cancellationToken)
        {
            var customerId = int.Parse(User.Claims.First().Value);

            var CustomerRequests = await _requestAppService.GetCustomerRequests(customerId, cancellationToken);

            return View(CustomerRequests);
        }


        [HttpGet]
        public async Task<IActionResult> GetRequestBids(int id, CancellationToken cancellationToken)
        {
            var bids = await _bidAppService.GetForRequest(id, cancellationToken);
            return View(bids);
        }


        [HttpGet]
        public async Task<IActionResult> GetExpertComments(int expertId, CancellationToken cancellationToken)
        {
            var expeetComments = _commentAppSerivce.GetForExpert(expertId, cancellationToken);
            return View(expeetComments);
        }


        [HttpGet]
        public async Task<IActionResult> AccesptBid(int id, CancellationToken cancellationToken)
        {
            await _bidAppService.IsAccepted(id, cancellationToken);
            return RedirectToAction("RequestList");
        }

        //[HttpPost]
        //public async Task<IActionResult> WriteCommentForExpert(int expertId,CancellationToken cancellationToken)
        //{

        //}

        [HttpGet]
        public async Task<IActionResult> RemoveRequest(int id, CancellationToken cancellationToken)
        {
            return RedirectToAction("RequestList");
        }
    }
}

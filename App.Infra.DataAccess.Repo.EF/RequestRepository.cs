using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.BidEntity.DTOs;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Framework;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class RequestRepository : IRequestRepository
    {
        #region Fields
        private readonly AppDbContext _context;
        #endregion

        #region ctor
        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementations
        public async Task<bool> Accept(int id, CancellationToken cancellationToken)
        {
            var targetRequest = await FindById(id, cancellationToken);
            if (targetRequest != null)
            {
                targetRequest.IsAccepted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> Reject(int requestId, CancellationToken cancellationToken)
        {
            var targetRequest = await FindById(requestId, cancellationToken);
            if (targetRequest != null)
            {
                targetRequest.IsAccepted = false;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken)
        {
            var newRequest = new Request
            {
                CustomerId = newRequestDto.CustomerId,
                Description = newRequestDto.Description,
                ServiceId = newRequestDto.ServiceId,
                ImageSrc = newRequestDto.ImageAddress,
                DateFor = newRequestDto.DateFor
            };

            await _context.Requests.AddAsync(newRequest, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var targetRequest = await FindById(id, cancellationToken);
            if (targetRequest != null)
            {
                targetRequest.IsDeleted = true;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<List<RequestDto>> GetAll(CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.Select(r => new RequestDto
            {
                RequestId = r.Id,
                ServiceTitle = r.Service.Title,
                CustomerName = r.Customer.FullName,
                Status = r.Status,
                IsAccepted = r.IsAccepted
            }).ToListAsync(cancellationToken);
            return requests;
        }

        public async Task<int> GetRequestsCount(CancellationToken cancellationToken)
        {
            var requestCount = await _context.Requests.CountAsync();
            return requestCount;
        }

        public async Task<RequestDetailsDto> GetById(int requestId, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.Where(r => r.Id == requestId)
                .Select(r => new RequestDetailsDto
                {
                    RequestId = r.Id,
                    Description = r.Description,
                    ImageSrc = r.ImageSrc,
                    CustomerFullName = r.Customer.FullName,
                    RequestStatus = r.Status,
                    IsAccepted = r.IsAccepted
                }).FirstOrDefaultAsync(cancellationToken);

            return request ?? throw new Exception($"Request with Id {requestId} not found");
        }

        public async Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.Where(r => r.CustomerId == customerId && r.Status != Status.RequestResponsed)
                .Select(r => new CustomerRequestDto
                {
                    RequestId = r.Id,
                    ServiceTitle = r.Service.Title,
                    RequestImage = r.ImageSrc,
                    CreateDateFa = r.CreatedAt.ToPersianString("dddd, dd MMMM,yyyy"),
                    Status = r.Status,
                    Bids = r.Bids.Select(b => new CustomerRequestBidsDto
                    {
                        BidId = b.Id,
                        Description = b.Description,
                        ExpertFullName = b.Expert.FullName,
                        ExpertId = b.Expert.Id,
                        Price = b.Price,
                        FinishedAtFa = b.FinishedAt.ToPersianString("dddd, dd MMMM,yyyy"),
                        IsAccepted = b.IsAccepted
                    }).ToList()
                }).OrderByDescending(r => r.RequestId).ToListAsync(cancellationToken);

            return requests;
        }

        public async Task<List<RequestDto>> GetRequestsForExpert(List<int> categoryIds, int expertId, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.Where(r => categoryIds.Contains(r.Service.CategoryId) && r.Status != Status.WaitingForAcceptRequest)
                .Select(r => new RequestDto
                {
                    RequestId = r.Id,
                    ServiceTitle = r.Service.Title,
                    CustomerName = r.Customer.FullName,
                    Status = r.Status,
                    HasExpertBid = r.Bids.Any(b => b.ExpertId == expertId),
                    IsAcceptedBid = r.Bids.FirstOrDefault(b => b.ExpertId == expertId).IsAccepted,
                    IsAccepted = r.IsAccepted
                }).OrderByDescending(r => r.RequestId).ToListAsync(cancellationToken);

            return requests;
        }

        public async Task<List<RequestDto>> GetFinishedReqeustsForExpert(int expertId, CancellationToken cancellationToken)
        {
            var reqeusts = await _context.Requests.AsNoTracking().Where(r => r.Bids.Any(b => b.ExpertId == expertId && b.IsAccepted == true) && r.Status == Status.RequestResponsed)
                .Select(r => new RequestDto
                {
                    CustomerName = r.Customer.FullName,
                    Status = r.Status,
                    ServiceTitle = r.Service.Title,
                }).ToListAsync(cancellationToken);

            return reqeusts ?? new List<RequestDto>();
        }

        public async Task<List<CustomerRequestDto>> GetFinishedRequestsForCustomer(int customerId, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.Where(r => r.CustomerId == customerId && r.Status == Status.RequestResponsed)
                .Select(r => new CustomerRequestDto
                {
                    RequestId = r.Id,
                    ExpertId = r.AcceptedExpertId,
                    RequestImage = r.ImageSrc,
                    ServiceTitle = r.Service.Title,
                    CreateDateFa = r.CreatedAt.ToPersianString("dddd, dd MMMM,yyyy"),
                    Status = r.Status,
                    Comment = r.Comment,
                }).ToListAsync(cancellationToken);

            return requests ?? new List<CustomerRequestDto>();
        }

        public async Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests.AsNoTracking().Where(r => r.ServiceId == serviceId).ToListAsync(cancellationToken);
            return requests;
        }

        public async Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken)
        {
            var request = await FindById(requestId, cancellationToken);
            request.Status = status;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SetExpert(int requestId, int expertId, CancellationToken cancellationToken)
        {
            var request = await FindById(requestId, cancellationToken);
            request.AcceptedExpertId = expertId;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SetComment(int requestId, int commentId, CancellationToken cancellationToken)
        {
            var request = await FindById(requestId, cancellationToken);
            request.CommentId = commentId;
            await _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Private Methods
        private async Task<Request> FindById(int id, CancellationToken cancellationToken)
        {
            var request = await _context.Requests.FindAsync(id, cancellationToken);
            return request ?? throw new Exception($"Request with Id {id} not found");
        }
        #endregion
    }
}

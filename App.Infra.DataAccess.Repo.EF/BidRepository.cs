using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using App.Infra.DB.SQLServer.EF.Migrations;
using Framework;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class BidRepository : IBidRepository
    {
        #region Fields
        private readonly AppDbContext context;
        #endregion

        #region ctors
        public BidRepository(AppDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Implementations
        public async Task<bool> Create(Bid bid, CancellationToken cancellationToken)
        {
            await context.Bids.AddAsync(bid, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Bid> GetById(int id, CancellationToken cancellationToken)
        {
            var bid = await context.Bids.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            return bid ?? new Bid();
        }

        public async Task<List<CustomerRequestBidsDto>> GetForRequest(int RequestId, CancellationToken cancellationToken)
        {
            var bids = await context.Bids.Where(b => b.RequestId == RequestId)
                .Select(b => new CustomerRequestBidsDto
                {
                    BidId = b.Id,
                    Description = b.Description,
                    Price = b.Price,
                    ExpertFullName = b.Expert.FullName,
                    ExpertId = b.ExpertId,
                    IsAccepted = b.IsAccepted,
                    FinishedAtFa = b.FinishedAt.ToPersianString("dddd, dd MMMM, yyyy"),
                    IsRequestHasAcceptedBid = b.Request.IsAcceptBid
                }).ToListAsync(cancellationToken);

            return bids;
        }

        public async Task<bool> AcceptBid(int bidId, CancellationToken cancellationToken)
        {
            var targetBid = await FindBid(bidId, cancellationToken);
            if (targetBid != null)
            {
                targetBid.IsAccepted = true;
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
        #endregion

        #region Private Methods
        private async Task<Bid> FindBid(int id, CancellationToken cancellationToken)
        {
            var bid = await context.Bids.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            if (bid != null)
            {
                return bid;
            }
            throw new Exception($"Suggestion with Id {id} not found");
        }
        #endregion
    }
}

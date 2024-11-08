﻿using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Domain.Core.BidEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
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
        public async Task<bool> Create(CreateBidDto createBidDto, CancellationToken cancellationToken)
        {
            var newBid = new Bid()
            {
                Description = createBidDto.Description,
                ExpertId = createBidDto.ExpertId,
                Price = createBidDto.Price,
                RequestId = createBidDto.RequestId,
                FinishedAt = createBidDto.DateFor,
            };
            await context.Bids.AddAsync(newBid, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Bid> GetById(int id, CancellationToken cancellationToken)
        {
            var bid = await context.Bids.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            return bid ?? new Bid();
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
        private async Task<Bid> FindBid(int bidId, CancellationToken cancellationToken)
        {
            var bid = await context.Bids.FirstOrDefaultAsync(b => b.Id == bidId, cancellationToken);
            return bid ?? throw new Exception($"Suggestion with Id {bidId} not found");
        }
        #endregion
    }
}

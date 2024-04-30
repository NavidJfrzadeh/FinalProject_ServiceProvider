using App.Domain.Core.BidEntity;
using App.Domain.Core.BidEntity.Contracts;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext context;

        public BidRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Create(Bid bid)
        {
            context.Bids.Add(bid);
            context.SaveChanges();
            return true;
        }

        public Bid GetById(int id) => context.Bids.AsNoTracking().FirstOrDefault(b => b.Id == id);

        public List<Bid> GetForRequest(int RequestId)
        {
            var bids = context.Bids.AsNoTracking().Where(b => b.RequestId == RequestId).ToList();
            return bids;
        }

        public bool IsAccepted(int id)
        {
            var targetBid = GetById(id);
            if (targetBid != null)
            {
                targetBid.IsAccepted = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

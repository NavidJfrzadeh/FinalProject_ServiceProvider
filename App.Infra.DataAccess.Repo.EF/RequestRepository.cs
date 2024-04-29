using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Infra.DB.SQLServer.EF;

namespace App.Infra.DataAccess.Repo.EF
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;

        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool Accept(int id)
        {
            var targetRequest = GetById(id);
            if (targetRequest != null)
            {
                targetRequest.IsAccepted = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Create(Request newRequest)
        {
            _context.Requests.Add(newRequest);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var targetRequest = GetById(id);
            if (targetRequest != null)
            {
                targetRequest.IsDeleted = true;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Request> GetAll() => _context.Requests.ToList();

        public Request GetById(int id) => _context.Requests.FirstOrDefault(r => r.Id == id);

        public List<Request> GetForService(int serviceId)
        {
            var requests = _context.Requests.Where(r=>r.ServiceId == serviceId).ToList();
            return requests;
        }
    }
}

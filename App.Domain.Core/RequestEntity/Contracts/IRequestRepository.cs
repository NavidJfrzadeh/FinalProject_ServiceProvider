namespace App.Domain.Core.RequestEntity.Contracts
{
    public interface IRequestRepository
    {
        public bool Create(Request newRequest);
        public Request GetById(int id);
        public List<Request> GetAll();
        public List<Request> GetForService(int serviceId);
        public bool Accept(int id);
        public bool Delete(int id);
    }
}

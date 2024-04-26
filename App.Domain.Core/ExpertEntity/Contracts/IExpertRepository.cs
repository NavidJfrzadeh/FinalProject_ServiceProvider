namespace App.Domain.Core.ExpertEntity.Contracts
{
    public interface IExpertRepository
    {
        public Expert GetById(int id);
        public List<Expert> GetAll();
        public bool Register(Expert newExpert);
    }
}

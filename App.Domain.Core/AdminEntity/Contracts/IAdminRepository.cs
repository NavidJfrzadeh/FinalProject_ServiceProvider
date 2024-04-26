namespace App.Domain.Core.AdminEntity.Contracts
{
    public interface IAdminRepository
    {
        public Admin GetById(int id);
    }
}

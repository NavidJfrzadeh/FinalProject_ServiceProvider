using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core._2_Configs;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace App.Infra.Db.SqlServer.Dapper
{
    public class RequestDapperRepository : IRequestRepository
    {
        private readonly SiteSettings _siteSettings;

        public RequestDapperRepository(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public Task<bool> Accept(int requestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

        }

        public async Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken)
        {
            IDbConnection connectionString = new SqlConnection(_siteSettings.SqlConfigurations.ConnectionString);
            var q = "INSERT INTO [dbo].[Requests] " +
                "(" +
                " [ServiceId],[CustomerId],[Description],[ImageSrc],[DateFor] " +
                ")" +
                "VALUES " +
                "@ServiceId , @ CustomerId, @Description, @ImageAddress,@DateFor" +
                ")";

            CommandDefinition command = new(q, new { ServiceId = newRequestDto.ServiceId, CustomerId = newRequestDto.CustomerId, Description = newRequestDto.Description, ImageSrc = newRequestDto.ImageAddress, DateFor = newRequestDto.DateFor });
            await connectionString.ExecuteAsync(command);
            return true;
        }

        public Task<bool> Delete(int requestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RequestDto>> GetAll(CancellationToken cancellationToken)
        {
            using var connectionString = new SqlConnection(_siteSettings.SqlConfigurations.ConnectionString);

            string querySql = "Select * From Reqeusts as R " +
                "Left Join Customers as C On R.CustomerId = C.CustomerId" +
                "Left Join Services as S On R.ServiceId = S.ServiceId";

            var cmd = new CommandDefinition(querySql);
            return (List<RequestDto>)await connectionString.QueryAsync(cmd);
        }

        public Task<RequestDetailsDto> GetById(int requestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerRequestDto>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestDto>> GetFinishedReqeustsForExpert(int expertId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerRequestDto>> GetFinishedRequestsForCustomer(int customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRequestsCount(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<RequestDto>> GetRequestsForExpert(List<int> categoryIds, int expertId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Reject(int requestId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetComment(int requestId, int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetExpert(int requestId, int expertId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

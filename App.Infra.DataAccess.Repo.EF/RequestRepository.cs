﻿using App.Domain.Core._0_BaseEntities.Enums;
using App.Domain.Core.RequestEntity;
using App.Domain.Core.RequestEntity.Contracts;
using App.Domain.Core.RequestEntity.DTOs;
using App.Infra.DB.SQLServer.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

		public async Task<bool> Create(CreateRequestDto newRequestDto, CancellationToken cancellationToken)
		{
			var newRequest = new Request
			{
				CustomerId = newRequestDto.CustomerId,
				Description = newRequestDto.Description,
				ServiceId = newRequestDto.ServiceId,
				ImageSrc = newRequestDto.RequestImage
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
			var requests = await _context.Requests.AsNoTracking().Select(r => new RequestDto
			{
				RequestId = r.Id,
				ServiceTitle = r.Service.Title,
				CustomerName = r.Customer.FullName,
				Status = r.Status,
				IsAccepted = r.IsAccepted
			}).ToListAsync(cancellationToken);
			return requests;
		}

		public async Task<Request> GetById(int id, CancellationToken cancellationToken)
		{
			var request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
			if (request != null)
			{
				return request;
			}
			return new Request();
		}

		public async Task<List<Request>> GetForService(int serviceId, CancellationToken cancellationToken)
		{
			var requests = await _context.Requests.AsNoTracking().Where(r => r.ServiceId == serviceId).ToListAsync(cancellationToken);
			return requests;
		}

		public async Task SetRequestStatus(int requestId, Status status, CancellationToken cancellationToken)
		{
			var request = await _context.Requests.FirstOrDefaultAsync(r => r.Id == requestId, cancellationToken);
			request.Status = status;
			await _context.SaveChangesAsync(cancellationToken);
		}
		#endregion

		#region Private Methods
		private async Task<Request> FindById(int id, CancellationToken cancellationToken)
		{
			var request = await _context.Requests.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
			if (request != null)
			{
				return request;
			}

			throw new Exception($"Request with Id {id} not found");
		}
		#endregion
	}
}

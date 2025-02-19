﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;
using TripTrackerCore.Repositories;
using TripTrackerCore.Services;
using TripTrackerCore.UnitOfWorks;
using TripTrackerService.Exceptions;

namespace TripTrackerService.Services
{
	public class Service<T> : IService<T> where T : class
	{
		private readonly IGenericRepository<T> _repository;
		private readonly IUnitOfWork _unitOfWork;

		public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			_repository = repository;
		}


		public async Task<T> AddAsync(T entity)
		{
            await _repository.AddAsync(entity);
			await _unitOfWork.CommitAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
		{
			await _repository.AddRangeAsync(entities);
			await _unitOfWork.CommitAsync();
			return entities;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return await _repository.AnyAsync(expression);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _repository.GetAll().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var hasItem = await _repository.GetByIdAsync(id);

			if (hasItem == null) 
			{
				throw new ClientSideException($"{typeof(T).Name} not found");
			}
			return hasItem;
		}

		public async Task RemoveAsync(T entity)
		{
			_repository.Remove(entity);
			await _unitOfWork.CommitAsync();
		}


		public async Task UpdateAsync(T entity)
		{
			_repository.Update(entity);
			await _unitOfWork.CommitAsync();
		}

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return _repository.Where(expression);
		}
		public async Task RemoveRange(IEnumerable<T> entities)
		{
			_repository.RemoveRange(entities);
			await _unitOfWork.CommitAsync();
		}

        public async Task<IEnumerable<T>> GetAllAdminsAsync()
        {
            if (typeof(T) == typeof(Staff))
            {
                var staffRepository = _repository as IGenericRepository<Staff>;

                if (staffRepository == null)
                {
                    throw new InvalidOperationException("The repository could not be cast to IGenericRepository<Staff>.");
                }

                return (IEnumerable<T>)await staffRepository.Where(s => s.isAdmin).ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("GetAllAdminsAsync only supports Staff entities.");
            }
        }


        //Business Kodlarının olacağı yer.
    }
}

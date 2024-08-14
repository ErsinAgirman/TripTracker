using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerCore.Repositories;
using TripTrackerCore.Services;
using TripTrackerCore.UnitOfWorks;

namespace TripTrackerService.Services
{
	public class TravelService : Service<Travel>, ITravelService
	{

		private readonly ITravelRepository _travelRepository;
		private readonly IMapper _mapper;

		public TravelService(IGenericRepository<Travel> repository, IUnitOfWork unitOfWork, IMapper mapper, ITravelRepository travelRepository) : base(repository, unitOfWork)
		{
			_mapper = mapper;
			_travelRepository = travelRepository;
		}
		public async Task<CustomResponseDto<List<TravelWithStaffDto>>> GetTravelWithStaff()
		{
			var travels = await _travelRepository.GetTravelWithStaff();
			var travelsDto = _mapper.Map<List<TravelWithStaffDto>>(travels);
			return CustomResponseDto<List<TravelWithStaffDto>>.Success(200, travelsDto);
		}
	}
}

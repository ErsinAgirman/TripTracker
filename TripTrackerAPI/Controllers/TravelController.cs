using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TripTrackerAPI.Filters;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerCore.Services;

namespace TripTrackerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TravelController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Travel> _service;
		private readonly ITravelService travelService;

		public TravelController(IService<Travel> service, IMapper mapper, ITravelService travelService)
		{
			_mapper = mapper;
			_service = service;
			this.travelService = travelService;
		}

		[HttpGet("[action]")]
		public async Task<IActionResult> GetTravelWithStaff()
		{
			return CreateActionResult(await travelService.GetTravelWithStaff());
		}



		[HttpGet]
		public async Task<IActionResult> All()
		{
			var travels = await _service.GetAllAsync();
			var TravelsDto = _mapper.Map<List<TravelDto>>(travels.ToList());
			return CreateActionResult<List<TravelDto>>(CustomResponseDto<List<TravelDto>>.Success(200, TravelsDto));
		}

		[ServiceFilter(typeof(NotFoundFilter<Travel>))]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var travel = await _service.GetByIdAsync(id);
			var TravelsDto = _mapper.Map<TravelDto>(travel);
			return CreateActionResult(CustomResponseDto<TravelDto>.Success(200, TravelsDto));
		}

		[HttpPost]
		public async Task<IActionResult> Save(TravelDto travelDto)
		{
            if (!travelDto.StatusId.HasValue)
            {
                travelDto.StatusId = 3; 
            }

            var travel = await _service.AddAsync(_mapper.Map<Travel>(travelDto));
			var TravelsDto = _mapper.Map<TravelDto>(travel);
			return CreateActionResult(CustomResponseDto<TravelDto>.Success(201, TravelsDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(TravelDto travelDto)
		{
			await _service.UpdateAsync(_mapper.Map<Travel>(travelDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}

		[ServiceFilter(typeof(NotFoundFilter<Travel>))]

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var travel = await _service.GetByIdAsync(id);

    //        if (travel == null)
    //        {
				//return CreateActionResult(CustomResponseDto<TravelDto>.Fail(404, "Bu Id ye sahip bir Seyahat Yok!"));
    //        }

			await _service.RemoveAsync(travel);
			return CreateActionResult(CustomResponseDto<TravelDto>.Success(204));
        }

	}
}

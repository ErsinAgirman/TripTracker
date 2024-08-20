using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTrackerAPI.Filters;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerCore.Services;

namespace TripTrackerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatusController : CustomBaseController
	{

		private readonly IMapper _mapper;
		private readonly IService<Status> _service;

		public StatusController(IService<Status> service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var status = await _service.GetAllAsync();
			var StatusesDto = _mapper.Map<List<StatusDto>>(status.ToList());
			return CreateActionResult<List<StatusDto>>(CustomResponseDto<List<StatusDto>>.Success(200, StatusesDto));
		}

		[ServiceFilter(typeof(NotFoundFilter<Status>))]

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var status = await _service.GetByIdAsync(id);
			var StatusDto = _mapper.Map<StatusDto>(status);
			return CreateActionResult(CustomResponseDto<StatusDto>.Success(200, StatusDto));
		}

		[HttpPost]
		public async Task<IActionResult> Save(StatusDto statusDto)
		{
            var status = await _service.AddAsync(_mapper.Map<Status>(statusDto));
			var StatusDto = _mapper.Map<StatusDto>(status);
			return CreateActionResult(CustomResponseDto<StatusDto>.Success(201, StatusDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(StatusDto statusDto)
		{
			await _service.UpdateAsync(_mapper.Map<Status>(statusDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}

		[ServiceFilter(typeof(NotFoundFilter<Status>))]

		[HttpDelete]
		public async Task<IActionResult> Remove(int id)
		{
			var status = await _service.GetByIdAsync(id);
    //        if (status == null)
    //        {
				//return CreateActionResult(CustomResponseDto<StatusDto>.Success(204));
    //        }
			await _service.RemoveAsync(status);
			return CreateActionResult(CustomResponseDto<StatusDto>.Success(204));
		}

	}
}

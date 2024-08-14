using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerCore.Services;

namespace TripTrackerAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StaffController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Staff> _service;

		public StaffController(IService<Staff> service,IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var staffs = await _service.GetAllAsync();

			var StaffsDto = _mapper.Map<List<StaffDto>>(staffs.ToList());
			//return Ok(CustomResponseDto<List<AdminDto>>.Success(200, AdminDtos));
			return CreateActionResult<List<StaffDto>>(CustomResponseDto<List<StaffDto>>.Success(200,StaffsDto));
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var staff = await _service.GetByIdAsync(id);

			var StaffsDto = _mapper.Map<StaffDto>(staff);
			return CreateActionResult(CustomResponseDto<StaffDto>.Success(200, StaffsDto));
		}


		[HttpPost]
		public async Task<IActionResult> Save(StaffDto staffDto)
		{
			var staff = await _service.AddAsync(_mapper.Map<Staff>(staffDto));

			var StaffsDto = _mapper.Map<AdminDto>(staff);
			return CreateActionResult(CustomResponseDto<AdminDto>.Success(201, StaffsDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(StaffDto staffDto)
		{
			await _service.UpdateAsync(_mapper.Map<Staff>(staffDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));	
		}

		[HttpDelete]
		public async Task<IActionResult> Remove(int id)
		{
			var staff = await _service.GetByIdAsync(id);

            if (staff == null)
            {
				return CreateActionResult(CustomResponseDto<AdminDto>.Fail(404, "Bu Id ye sahip Personel Yok!"));
            }

			await _service.RemoveAsync(staff);
			return CreateActionResult(CustomResponseDto<AdminDto>.Success(204));
        }

	}
}

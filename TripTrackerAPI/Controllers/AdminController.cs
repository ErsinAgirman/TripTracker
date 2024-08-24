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
	public class AdminController : CustomBaseController
	{
		private readonly IMapper _mapper;
		private readonly IService<Staff> _service;

		public AdminController(IMapper mapper, IService<Staff> service)
		{
			_mapper = mapper;
			_service = service;
		}

        //[HttpGet]
        //public async Task<IActionResult> All()
        //{
        //	var admins = await _service.GetAllAsync();  
        //          var AdminsDto = _mapper.Map<List<AdminDto>>(admins.ToList());
        //	//return Ok(CustomResponseDto<List<AdminDto>>.Success(200, AdminDtos));
        //	return CreateActionResult<List<AdminDto>>(CustomResponseDto<List<AdminDto>>.Success(200, AdminsDto));
        //}

        [HttpGet]
        public async Task<IActionResult> AllAdmins()
        {
            var admins = await _service.GetAllAdminsAsync();
            var adminsDto = _mapper.Map<List<AdminDto>>(admins);
            return CreateActionResult<List<AdminDto>>(CustomResponseDto<List<AdminDto>>.Success(200, adminsDto));
        }

        //[ServiceFilter(typeof(NotFoundFilter<Staff>))]

        [HttpGet ("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var admin = await _service.GetByIdAsync(id);

			var AdminsDto = _mapper.Map<AdminDto>(admin);
			return CreateActionResult(CustomResponseDto<AdminDto>.Success(200, AdminsDto));
		}

		[HttpPost]
		public async Task<IActionResult> Save(AdminDto adminDto)
		{
			var admin = await _service.AddAsync(_mapper.Map<Staff>(adminDto));

			var AdminsDto = _mapper.Map<AdminDto>(admin);
			return CreateActionResult(CustomResponseDto<AdminDto>.Success(201, AdminsDto));
		}

		[HttpPut]
		public async Task<IActionResult> Update(AdminDto adminDto)
		{
			await _service.UpdateAsync(_mapper.Map<Staff>(adminDto));
			return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
		}


		//[ServiceFilter(typeof(NotFoundFilter<Staff>))]

		[HttpDelete("{id}")]
		public async Task<IActionResult> Remove(int id)
		{
			var admin = await _service.GetByIdAsync(id);

			//if(admin == null)
			//{
			//	return CreateActionResult(CustomResponseDto<AdminDto>.Fail(404,"Bu Id ye sahip Yönetici Yok!"));
			//}
			await _service.RemoveAsync(admin);
			return CreateActionResult(CustomResponseDto<AdminDto>.Success(204));
		}
	}
}

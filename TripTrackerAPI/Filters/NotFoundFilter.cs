using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;
using TripTrackerCore.Services;

namespace TripTrackerAPI.Filters
{
	public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
	{
		private readonly IService<T> _service;

		public NotFoundFilter(IService<T> service)
		{
			_service = service;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{

			var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
				await next.Invoke();
				return;
            }
			var id =(int)idValue;
			var anyEntity = await _service.AnyAsync(x=> x.Id == id);

			if (anyEntity) 
			{
				await next.Invoke();
				return;
			}

			context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(400, $"{typeof(T).Name}({id}) Not Found..."));
            

			//Exception GetById methodunun içerisine girip bulamazsa hata fırlatır ancak filter ile önce taranır
		}
	}
}

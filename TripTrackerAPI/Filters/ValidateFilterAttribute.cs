using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TripTrackerCore.DTOs;

namespace TripTrackerAPI.Filters
{
	public class ValidateFilterAttribute : ActionFilterAttribute
	{
		//Controller içerisindeki metotlara gelen request e müdahale etmek için kullanılır
		//Rquest gelmeden önce, geldikten sonra,action method çalışmadan önce,sonra.. erişmemizi sağlar.
		public override void OnActionExecuting(ActionExecutingContext context)
		{
            if (!context.ModelState.IsValid)
            {
				var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

				context.Result = new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(400, errors));
				
            }
        }
	}
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;

namespace TripTrackerService.Validations
{
	public class StaffDtoValidator : AbstractValidator<StaffDto>
	{	
		public StaffDtoValidator() 
		{
			RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
			RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
		}
	}
}

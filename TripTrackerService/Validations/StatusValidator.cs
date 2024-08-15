using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;

namespace TripTrackerService.Validations
{
	public class StatusValidator: AbstractValidator<StatusDto>
	{
        public StatusValidator()
        {
			RuleFor(x => x.Information).NotNull().WithMessage("{PropertyName} is Required").NotEmpty().WithMessage("{PropertyName is Required");
		}
    }
}

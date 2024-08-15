using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;

namespace TripTrackerService.Validations
{
	public class TravelValidator : AbstractValidator<TravelDto>
	{
        public TravelValidator()
        {

			RuleFor(x => x.Description)
				.NotNull().WithMessage("{PropertyName} is Required")
				.NotEmpty().WithMessage("{PropertyName is Required");

			RuleFor(x => x.City)
				.NotNull().WithMessage("{PropertyName} is Required")
				.NotEmpty().WithMessage("{PropertyName is Required");

			RuleFor(x => x.StartDate)
				.NotNull().WithMessage("Start Date is Required")
				.NotEmpty().WithMessage("Start Date is Required");
				//.LessThanOrEqualTo(DateTime.Now).WithMessage("Start Date can not be in the future");

			RuleFor(x => x.EndDate)
				.NotNull().WithMessage("End Date is Required")
				.NotEmpty().WithMessage("End Date is Required")
				.GreaterThanOrEqualTo(x => x.StartDate).WithMessage("End Date must be after Start Date");


			RuleFor(x => x.Stay)
				.NotNull().WithMessage("Stay is Required")
				.NotEmpty().WithMessage("Stay is Required");


			RuleFor(x => x.Vehicle)
				.NotNull().WithMessage("Stay is Required")
				.NotEmpty().WithMessage("Stay is Required");

		}
    }
}

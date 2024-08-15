using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;

namespace TripTrackerService.Validations
{
	public class AdminDtoValidator : AbstractValidator<AdminDto>
	{
        public AdminDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is Required").NotEmpty().WithMessage("{PropertyName is Required");
            RuleFor(x => x.Surname).NotNull().WithMessage("{PropertyName} is Required").NotEmpty().WithMessage("{PropertyName is Required");
        }
    }
}

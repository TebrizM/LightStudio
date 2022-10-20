using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CountryDto
{
    public class CountryPutDto
    {
        public string Name { get; set; }
    }
    public class CountryPutDtoValidator : AbstractValidator<CountryPutDto>
    {
        public CountryPutDtoValidator()
        {

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");
        }
    }
}

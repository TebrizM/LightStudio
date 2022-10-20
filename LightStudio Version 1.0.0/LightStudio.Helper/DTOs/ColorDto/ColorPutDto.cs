using FluentValidation;
using LightStudio.Helper.DTOs.CountryDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ColorDto
{
    public class ColorPutDto
    {
        public string Name { get; set; }
    }
    public class ColorPutDtoValidator : AbstractValidator<ColorPutDto>
    {
        public ColorPutDtoValidator()
        {

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");
        }
    }
}
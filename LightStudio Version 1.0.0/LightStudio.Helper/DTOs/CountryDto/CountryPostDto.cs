using FluentValidation;
using LightStudio.Helper.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CountryDto
{
    public class CountryPostDto
    {
        public string Name { get; set; }

        public int ProductId { get; set; }
    
        public int CountryId { get; set; }

    }
    public class CountryPostDtoValidator : AbstractValidator<CountryPostDto>
    {
        public CountryPostDtoValidator()
        {

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");
        }
    }
}

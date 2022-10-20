﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CategoryDto
{
    public class CategoryPutDto
    {
        public string Name { get; set; }
    }
    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator()
        {
           

            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character");
        }
    }
}

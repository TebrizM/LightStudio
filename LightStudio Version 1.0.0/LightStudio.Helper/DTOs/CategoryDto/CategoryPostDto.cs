﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CategoryDto
{
    public class CategoryPostDto
    {
        public string Name { get; set; }
    }
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator()
        {
         

            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character")
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}

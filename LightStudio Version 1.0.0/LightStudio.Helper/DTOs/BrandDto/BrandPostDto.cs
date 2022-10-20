﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.BrandDto
{
    public class BrandPostDto
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class BrandPostDtoValidator : AbstractValidator<BrandPostDto>
    {
        public BrandPostDtoValidator()
        {
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Photo.ContentType != "image/jpeg" && x.Photo.ContentType != "image/png")
                    context.AddFailure("ImageFile", "File type must be jpeg or png");
            });
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Photo.Length > 4194304)
                    context.AddFailure("ImageFile", "file size must be less than 4mb");
            });

            RuleFor(x => x.Name)
                .MaximumLength(20)
                .WithMessage("Max length must be less than 20 character")
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Desc)
                .MaximumLength(400)
                .WithMessage("Max length must be less than 400 character")
                .NotEmpty()
                .WithMessage("Name is required");
        }
    }
}

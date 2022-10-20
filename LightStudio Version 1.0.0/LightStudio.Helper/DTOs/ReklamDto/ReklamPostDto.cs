using FluentValidation;
using LightStudio.Helper.DTOs.ProductDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ReklamDto
{
    public class ReklamPostDto

    {
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string Info { get; set; }
        public string Contact { get; set; }
        public IFormFile Image { get; set; }
    }
    public class ReklamPostDtoValidator : AbstractValidator<ReklamPostDto>
    {
        public ReklamPostDtoValidator()
        {
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Image.ContentType != "image/jpeg" && x.Image.ContentType != "image/png")
                    context.AddFailure("ImageFile", "File type must be jpeg or png");
            });
            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Image.Length > 4194304)
                    context.AddFailure("ImageFile", "file size must be less than 4mb");
            });

            RuleFor(x => x.Info)
                .MaximumLength(150)
                .WithMessage("Max length must be less than 150 character");

            RuleFor(x => x.Title)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");

            RuleFor(x => x.Title2)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");

            RuleFor(x => x.Title3)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character");
        }
    }
}

﻿using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ProductDto
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Desc { get; set; }
        public int BrandId { get; set; }
        public string Size { get; set; }
        public int CountryId { get; set; }
        
        public IFormFile Photo { get; set; }
    }
    public class ProductPostDtoValidator : AbstractValidator<ProductPostDto>
    {
        public ProductPostDtoValidator()
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

            RuleFor(x => x.Desc)
               .MaximumLength(150)
               .WithMessage("Max length must be less than 150 character")
               .NotEmpty()
               .WithMessage("Description is required");

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Max length must be less than 100 character")
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.SalePrice)
                .NotEmpty()
                .WithMessage("Sale price is required!")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Sale price cannot be 0");

            RuleFor(x => x.CostPrice)
                .NotEmpty()
                .WithMessage("Cost price is required!")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Cost price cannot be 0");
        }
    }
}

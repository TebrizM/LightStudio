using LightStudio.Core.Entities;
using LightStudio.Helper.DTOs.BrandDto;
using LightStudio.Helper.DTOs.CategoryDto;
using LightStudio.Helper.DTOs.CountryDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ProductDto
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Size { get; set; }
        public string Desc { get; set; }
        public bool InStock { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public BrandGetDto Brand { get; set; }
        public CategoryGetDto Category { get; set; }
        public CountryGetDto Country { get; set; }


    }

}

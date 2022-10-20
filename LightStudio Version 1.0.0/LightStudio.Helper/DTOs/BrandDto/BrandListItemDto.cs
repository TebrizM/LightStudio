using LightStudio.Helper.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.BrandDto
{
    public class BrandListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductGetDto> Products { get; set; }
   
        public string Image { get; set; }
    }
}

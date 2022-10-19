using LightStudio.Helper.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CountryDto
{
    public class CountryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductGetDto> Products { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

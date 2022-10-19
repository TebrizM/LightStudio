using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ProductDto
{
    public class ProductDto
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
    }
}

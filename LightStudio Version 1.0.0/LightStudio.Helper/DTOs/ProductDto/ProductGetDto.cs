using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ProductDto
{
    public class ProductGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Size { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int BrandId { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
        public bool InStock { get; set; }
        public int CountryId { get; set; }

    }
}

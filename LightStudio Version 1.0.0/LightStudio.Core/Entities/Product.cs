using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal CostPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public bool InStock { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}

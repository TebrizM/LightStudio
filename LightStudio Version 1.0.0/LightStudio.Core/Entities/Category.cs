using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}

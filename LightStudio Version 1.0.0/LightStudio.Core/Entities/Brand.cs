using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Core.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Product> Products { get; set; }
    }
}

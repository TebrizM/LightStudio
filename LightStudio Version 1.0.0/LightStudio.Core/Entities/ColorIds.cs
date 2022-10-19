using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Core.Entities
{
    public class ColorIds
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public Color Color { get; set; }
        public Product Product { get; set; }
    }
}

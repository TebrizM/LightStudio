using LightStudio.Helper.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.ColorDto
{
    public class ColorGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

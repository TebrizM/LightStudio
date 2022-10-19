using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CategoryDto
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}

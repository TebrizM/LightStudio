using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.CategoryDto
{
    public class CategoryListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}

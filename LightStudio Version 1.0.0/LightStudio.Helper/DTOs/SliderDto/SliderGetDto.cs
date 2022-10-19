using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.SliderDto
{
    public class SliderGetDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Info { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.SliderDto
{
    public class SliderPostDto
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Title2 { get; set; }
        public string Info { get; set; }
        public int Order { get; set; }

    }
}

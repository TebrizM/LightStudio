using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.SettingsDto
{
    public class SettingsPostDto
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IFormFile Photo { get; set; }
    }
}

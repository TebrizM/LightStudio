using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.SettingsDto
{
    public class SettingsGetDto
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

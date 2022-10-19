using System;
using System.Collections.Generic;
using System.Text;

namespace LightStudio.Helper.DTOs.AccountDto
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}

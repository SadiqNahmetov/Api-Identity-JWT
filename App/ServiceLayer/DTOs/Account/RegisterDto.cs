﻿

namespace ServiceLayer.DTOs.Account
{
    public class RegisterDto
    {
        public string? Username { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

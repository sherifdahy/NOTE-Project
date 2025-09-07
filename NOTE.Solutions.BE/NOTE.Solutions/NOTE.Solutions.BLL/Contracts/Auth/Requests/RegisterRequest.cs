﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTE.Solutions.BLL.Contracts.Auth.Requests;

public class RegisterRequest
{
    public string Name { get; set; } = string.Empty;
    public string SSN { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
